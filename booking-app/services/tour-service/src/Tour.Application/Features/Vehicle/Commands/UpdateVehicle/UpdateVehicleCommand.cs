using MediatR;
using Shared.Common;

namespace Application.Features
{
    public record UpdateVehicleCommand(UpdateVehicleRequestDTO model) : IRequest<OperationResult<int>>;
}