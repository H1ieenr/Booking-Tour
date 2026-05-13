using Domain.Entities;
using Domain.Interfaces;
using Shared.Common;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Application.Features
{
    public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, OperationResult<int>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        public CreateVehicleHandler(
            IVehicleRepository vehicleRepository,
            IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> Handle(CreateVehicleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var vehicle = _mapper.Map<Vehicle>(command.model);
                await _vehicleRepository.AddAsync(vehicle);
                await _vehicleRepository.SaveChangesAsync(cancellationToken);
                return OperationResult<int>.Created(vehicle.id);
            }
            catch (Exception ex)
            {
                return OperationResult<int>.Failure($"{ex.Message}");
            }
        }
    }
}