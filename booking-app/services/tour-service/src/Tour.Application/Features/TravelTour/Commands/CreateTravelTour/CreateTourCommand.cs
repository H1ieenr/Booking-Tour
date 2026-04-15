using Shared.Common;
using MediatR;
namespace Tour.Application
{
    public record CreateTourCommand(CreateTourRequestDto TourDto) : IRequest<OperationResult<int>>;
}