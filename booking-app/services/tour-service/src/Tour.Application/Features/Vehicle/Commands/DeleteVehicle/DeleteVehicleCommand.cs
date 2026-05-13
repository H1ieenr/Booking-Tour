using MediatR;
using Shared.Common;

namespace Application.Features
{
    public record DeleteVehicleCommand(DeleteVehicleRequestDTO model) : IRequest<OperationResult<int>>;
}