using Shared.Common;
using MediatR;

namespace Application.Features
{
    public record GetTourByIdQuery(GetTravelTourByIdRequestDTO model) : IRequest<OperationResult<GetTravelTourByIdDTO>>;
}