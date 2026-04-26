using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Shared.Common;
using MediatR;

namespace Application.Features
{
    public class GetCategoriesLookupHandler : IRequestHandler<GetCategoriesLookupQuery, OperationResult<List<GetCategoriesLookupDTO>>>
    {
        private readonly string _connectionString;

        public GetCategoriesLookupHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<OperationResult<List<GetCategoriesLookupDTO>>> Handle(GetCategoriesLookupQuery query, CancellationToken cancellationToken)
        {
            using var db = new SqlConnection(_connectionString);
            var builder = new SqlBuilder();

            var sqlTemplate = @"SELECT id, name, image, sequence FROM Categories /**where**/ ORDER BY sequence";
            var selector = builder.AddTemplate(sqlTemplate);

            builder.Where("is_deleted = 0");
            if (!string.IsNullOrWhiteSpace(query.model.search_text))
            {
                builder.Where("name LIKE @Search", new { Search = $"%{query.model.search_text}%" });
            }

            var items = await db.QueryAsync<GetCategoriesLookupDTO>(selector.RawSql, selector.Parameters);
            return OperationResult<List<GetCategoriesLookupDTO>>.Success(items.ToList());
        }
    }
}