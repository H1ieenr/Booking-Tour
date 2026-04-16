using Shared.Common;
using MediatR;

namespace Tour.Application
{
    public record GetTourByIdQuery(GetTravelTourByIdRequestDTO model) : IRequest<OperationResult<GetTravelTourByIdDTO>>;
}