using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Shared.Common;
using Shared.Exceptions;
using System.Data;

namespace Tour.Application
{
    public class GetTourByIdHandler
    {
        private readonly string _connectionString;
        public GetTourByIdHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        public async Task<OperationResult<TravelTourDto>> Handle(GetTourByIdQuery query)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            const string sql = @"
                   SELECT t.Id, t.Title, t.CodeTour as Code, c.Name as CategoryName, t.BasePrice
                   FROM TravelTours t
                   LEFT JOIN Categories c ON t.CategoryId = c.Id
                   WHERE t.Id = @Id";

            var result = await db.QueryFirstOrDefaultAsync<TravelTourDto>(sql, new { Id = query.Id });

            if (result == null)
            {
                throw new NotFoundException($"Không tìm thấy Tour với ID: {query.Id}");
            }

            return OperationResult<TravelTourDto>.Success(result);
        }

    }
}