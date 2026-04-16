using Shared.Common;
using MediatR;
namespace Tour.Application
{
    public record CreateTravelTourCommand(CreateTravelTourRequestDto model) : IRequest<OperationResult<int>>;
}