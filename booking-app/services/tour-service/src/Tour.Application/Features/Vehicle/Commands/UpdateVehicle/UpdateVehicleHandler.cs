using Domain.Interfaces;
using Shared.Common;
using MediatR;
using AutoMapper;

namespace Application.Features
{
    public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommand, OperationResult<int>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public UpdateVehicleHandler(
            IVehicleRepository vehicleRepository,
            IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> Handle(UpdateVehicleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var vehicle = await _vehicleRepository.GetByIdAsync(command.model.id, cancellationToken);
                if (vehicle == null) return OperationResult<int>.Nodata(command.model.id);
                _mapper.Map(command.model, vehicle);

                _vehicleRepository.Update(vehicle);
                return OperationResult<int>.Updated(vehicle.id);
            }
            catch (Exception ex)
            {
                return OperationResult<int>.Failure($"{ex.Message}");
            }
        }
    }
}