using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Shared.Common;
using Shared.Exceptions;
using System.Data;
using MediatR;

namespace Application.Features
{
    public class GetVehicleByIdHandler : IRequestHandler<GetVehicleByIdQuery, OperationResult<GetVehicleByIdDTO>>
    {
        private readonly string _connectionString;
        public GetVehicleByIdHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<OperationResult<GetVehicleByIdDTO>> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            const string sql = @"SELECT c.id, c.name, c.license_plate, c.capacity, c.driver_name, driver_phone
                                status, current_odometer, c.created_date 
                                FROM Vehicles c WHERE c.Id = @Id";
            var command = new CommandDefinition(sql,
                        parameters: request.model,
                        cancellationToken: cancellationToken);

            var result = await db.QueryFirstOrDefaultAsync<GetVehicleByIdDTO>(command);

            if (result == null) return OperationResult<GetVehicleByIdDTO>.Nodata(result);
            return OperationResult<GetVehicleByIdDTO>.Success(result);
        }
    }
}