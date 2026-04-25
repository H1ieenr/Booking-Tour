using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Shared.Common;
using MediatR;

namespace Application.Features
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, PagedResult<CategoryItemDTO>>
    {
        private readonly string _connectionString;

        public GetCategoriesHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<PagedResult<CategoryItemDTO>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            using var db = new SqlConnection(_connectionString);
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate(@"
            SELECT COUNT(*) FROM Categories /**where**/;
            
            SELECT id, name, image, sequence, active 
            FROM Categories 
            /**where**/
            ORDER BY sequence
            OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;",
                new { request.PageSize, Offset = (request.PageNumber - 1) * request.PageSize });

            builder.Where("is_deleted = 0");

            if (!string.IsNullOrWhiteSpace(request.model.search_text))
            {
                builder.Where("name LIKE @search_text", new { search_text = $"%{request.model.search_text}%" });
            }

            if (request.model.is_active.HasValue)
            {
                builder.Where("active = @active", new { Active = request.model.is_active.Value });
            }

            using var multi = await db.QueryMultipleAsync(selector.RawSql, selector.Parameters);

            var totalCount = await multi.ReadFirstAsync<int>();
            var items = (await multi.ReadAsync<CategoryItemDTO>()).ToList();

            return new PagedResult<CategoryItemDTO>(items, totalCount, request.PageNumber, request.PageSize);
        }
    }
}