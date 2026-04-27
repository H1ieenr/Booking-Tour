using MediatR;
using Shared.Common;

namespace Application.Features
{
    public record UploadImagesCommand(UploadImagesRequestDTO model) : IRequest<OperationResult<List<string>>>;
}