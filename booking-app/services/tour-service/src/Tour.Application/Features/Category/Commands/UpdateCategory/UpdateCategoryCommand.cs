using MediatR;
using Shared.Common;

namespace Application.Features
{
    public record UpdateCategoryCommand(UpdateCategoryRequestDTO model) : IRequest<OperationResult<int>>;
}