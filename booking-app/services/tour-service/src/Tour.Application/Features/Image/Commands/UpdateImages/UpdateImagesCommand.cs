using MediatR;
using Shared.Common;

namespace Application.Features
{
    public record UpdateImagesCommand(UpdateImagesRequestDTO model) : IRequest<OperationResult<UpdateImagesDTO>>;
}