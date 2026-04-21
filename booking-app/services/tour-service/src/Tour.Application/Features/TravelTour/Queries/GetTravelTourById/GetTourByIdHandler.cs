using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Shared.Common;
using Shared.Exceptions;
using System.Data;
using MediatR;
using AutoMapper;

namespace Application.Features
{
    public class GetTourByIdHandler : IRequestHandler<GetTourByIdQuery, OperationResult<GetTravelTourByIdDTO>>
    {
        private readonly string _connectionString;
         private readonly IMapper _mapper; 
        public GetTourByIdHandler(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
            _mapper = mapper;
        }
        public async Task<OperationResult<GetTravelTourByIdDTO>> Handle(GetTourByIdQuery query, CancellationToken cancellationToken)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            const string sql = @"
                   SELECT t.Id, t.Title, t.CodeTour as Code, c.Name as CategoryName, t.BasePrice
                   FROM TravelTours t
                   LEFT JOIN Categories c ON t.CategoryId = c.Id
                   WHERE t.Id = @Id";
            var command = new CommandDefinition(sql, 
                        parameters: query.model,
                        cancellationToken: cancellationToken);

            var result = await db.QueryFirstOrDefaultAsync<GetTravelTourByIdDTO>(command);

            if (result == null)
            {
                throw new NotFoundException($"{query.model.id}");
            }
            return OperationResult<GetTravelTourByIdDTO>.Success(result);
        }

    }
}