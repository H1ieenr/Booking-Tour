using Microsoft.AspNetCore.Http;
namespace Shared.Infrastructure
{
    public interface ICloudinaryService
    {
        Task<CloudinaryResponse> UploadImageAsync(IFormFile file, string folderName = "webdev_uploads");
        Task<bool> DeleteImageAsync(string publicId);
    }
}