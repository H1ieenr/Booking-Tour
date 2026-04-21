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
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, OperationResult<GetCategoryByIdDTO>>
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;
        public GetCategoryByIdHandler(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
            _mapper = mapper;
        }
        public async Task<OperationResult<GetCategoryByIdDTO>> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            const string sql = @"SELECT c.Id, c.Name, c.Code, c.Description, c.Status FROM Categories c WHERE c.Id = @Id";
            var command = new CommandDefinition(sql,
                        parameters: query.model,
                        cancellationToken: cancellationToken);

            var result = await db.QueryFirstOrDefaultAsync<GetCategoryByIdDTO>(command);

            if (result == null)
            {
                throw new NotFoundException($"{query.model.id}");
            }
            return OperationResult<GetCategoryByIdDTO>.Success(result);
        }

    }
}