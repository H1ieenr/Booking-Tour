using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Shared.Common;
using MediatR;

namespace Application.Features
{
    public class GetVehiclesLookupHandler : IRequestHandler<GetVehiclesLookupQuery, OperationResult<List<GetVehiclesLookupDTO>>>
    {
        private readonly string _connectionString;

        public GetVehiclesLookupHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<OperationResult<List<GetVehiclesLookupDTO>>> Handle(GetVehiclesLookupQuery request, CancellationToken cancellationToken)
        {
            using var db = new SqlConnection(_connectionString);
            var builder = new SqlBuilder();

            var sqlTemplate = @"SELECT id, name, license_plate, capacity, driver_name, driver_phone
                               FROM Vehicles /**where**/ ORDER BY name";
            var selector = builder.AddTemplate(sqlTemplate);

            builder.Where("is_deleted = 0");
            if (!string.IsNullOrWhiteSpace(request.model.search_text))
            {
                builder.Where("name LIKE @Search", new { Search = $"%{request.model.search_text}%" });
            }
            if (request.model.list_status != null && request.model.list_status.Any())
            {
                builder.Where("status IN @list_status", new { list_status = request.model.list_status });
            }
            var items = await db.QueryAsync<GetVehiclesLookupDTO>(selector.RawSql, selector.Parameters);
            return OperationResult<List<GetVehiclesLookupDTO>>.Success(items.ToList());
        }
    }
}