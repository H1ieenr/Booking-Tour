using MediatR;
using Shared.Common;

namespace Application.Features
{
    public record CreateVehicleCommand(CreateVehicleRequestDTO model) : IRequest<OperationResult<int>>;
}