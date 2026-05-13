using Shared.Common;
using MediatR;

namespace Application.Features
{
    public record GetVehiclesLookupQuery(GetVehiclesLookupRequestDTO model) : IRequest<OperationResult<List<GetVehiclesLookupDTO>>>;
}