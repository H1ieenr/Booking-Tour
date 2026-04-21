using MediatR;
using Shared.Common;

namespace Application.Features
{
    public record DeleteCategoryCommand(DeleteCategoryRequestDTO model) : IRequest<OperationResult<int>>;
}