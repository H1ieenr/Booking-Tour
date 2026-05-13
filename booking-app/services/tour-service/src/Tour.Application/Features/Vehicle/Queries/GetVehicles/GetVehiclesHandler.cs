using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Shared.Common;
using MediatR;

namespace Application.Features
{
    public class GetVehiclesHandler : IRequestHandler<GetVehiclesQuery, OperationResult<PagedResult<VehicleItemDTO>>>
    {
        private readonly string _connectionString;

        public GetVehiclesHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<OperationResult<PagedResult<VehicleItemDTO>>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {

            using var db = new SqlConnection(_connectionString);
            var builder = new SqlBuilder();
            var sortBy = request.model.SortBy?.ToLower() switch
            {
                "name" => "name",
                "created_date" => "created_date",
                "capacity" => "capacity",
                _ => "name"
            };
            var sortDir = request.model.SortDir?.ToLower() == "desc" ? "DESC" : "ASC";

            var sqlTemplate = $@" SELECT COUNT(*) FROM Vehicles /**where**/;
                                SELECT id, name, license_plate, capacity, driver_name, driver_phone, 
                                        status, current_odometer, created_date FROM Vehicles 
                                /**where**/
                                ORDER BY {sortBy} {sortDir} 
                                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";
            var selector = builder.AddTemplate(sqlTemplate, new
            {
                request.PageSize,
                Offset = (request.PageNumber - 1) * request.PageSize
            });
            builder.Where("is_deleted = 0");

            if (!string.IsNullOrWhiteSpace(request.model.search_text))
            {
                builder.Where(@"( name LIKE @search_text OR
                                  license_plate LIKE @search_text OR
                                  CAST(capacity AS NVARCHAR(20)) LIKE @search_text OR
                                  driver_name LIKE @search_text OR
                                  driver_phone LIKE @search_text)",
                                 new { search_text = $"%{request.model.search_text}%" });
            }
            if (request.model.list_status != null && request.model.list_status.Any())
            {
                builder.Where("status IN @list_status", new { list_status = request.model.list_status });
            }
            using var multi = await db.QueryMultipleAsync(selector.RawSql, selector.Parameters);

            var totalCount = await multi.ReadFirstAsync<int>();
            var items = (await multi.ReadAsync<VehicleItemDTO>()).ToList();
            var result = new PagedResult<VehicleItemDTO>(items, totalCount, request.PageNumber, request.PageSize);
            return OperationResult<PagedResult<VehicleItemDTO>>.Success(result);
        }
    }
}