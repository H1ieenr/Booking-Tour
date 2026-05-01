using MediatR;
using Shared.Common;

namespace Application.Features
{
    public record SetMainImageCommand(SetMainImageRequestDTO model) : IRequest<OperationResult<int>>;
}