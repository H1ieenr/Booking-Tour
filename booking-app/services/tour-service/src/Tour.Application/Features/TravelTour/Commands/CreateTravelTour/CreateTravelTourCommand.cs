using Shared.Common;
using MediatR;
namespace Application.Features
{
    public record CreateTravelTourCommand(CreateTravelTourRequestDTO model) : IRequest<OperationResult<int>>;
}