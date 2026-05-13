using MediatR;
using Shared.Common;

namespace Application.Features
{
    public record GetVehicleByIdQuery(GetVehicleByIdRequestDTO model) : IRequest<OperationResult<GetVehicleByIdDTO>>;
}