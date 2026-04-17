using MediatR;
using Shared.Common;

namespace Application.Features
{
    public record CreateCategoryCommand(CreateCategoryRequestDTO model) : IRequest<OperationResult<int>>;
}