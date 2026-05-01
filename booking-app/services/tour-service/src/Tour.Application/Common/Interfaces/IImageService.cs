using Shared.Common;
using Microsoft.AspNetCore.Http;
using Application.Features;

namespace Application.Common
{
    public interface IImageService
    {
        Task<OperationResult<List<UploadImageDTO>>> ProcessAndSaveImagesAsync(List<IFormFile> files,
                    int travel_tour_id, string code_tour, string user_id);
        Task<OperationResult<List<DeleteImageDTO>>> DeleteImagesAsync(List<int> ids);
    }
}