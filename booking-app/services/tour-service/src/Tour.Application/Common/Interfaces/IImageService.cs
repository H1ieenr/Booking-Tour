using Shared.Common;
using Microsoft.AspNetCore.Http;

namespace Application.Common
{
    public interface IImageService
    {
        Task<OperationResult<List<string>>> ProcessAndSaveImagesAsync(List<IFormFile> files, 
                    int travel_tour_id, string code_tour, string user_id);
    }
}