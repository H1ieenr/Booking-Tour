using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;

namespace Shared.Infrastructure
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration config)
        {
            var acc = new Account(
                config["Cloudinary:CloudName"],
                config["Cloudinary:ApiKey"],
                config["Cloudinary:ApiSecret"]
            );
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<CloudinaryResponse> UploadImageAsync(IFormFile file, string folderName = "webdev_uploads")
        {
            if (file == null || file.Length == 0)
            {
                return new CloudinaryResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "File không hợp lệ hoặc trống."
                };
            }

            try
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = folderName,
                    // Tự động tối ưu hóa dung lượng và định dạng ảnh
                    Transformation = new Transformation().Quality("auto").FetchFormat("auto")
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                {
                    return new CloudinaryResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = uploadResult.Error.Message
                    };
                }

                return new CloudinaryResponse
                {
                    IsSuccess = true,
                    PublicId = uploadResult.PublicId,
                    Url = uploadResult.SecureUrl?.ToString()
                };
            }
            catch (Exception ex)
            {
                return new CloudinaryResponse
                {
                    IsSuccess = false,
                    ErrorMessage = $"Lỗi hệ thống: {ex.Message}"
                };
            }
        }

        public async Task<bool> DeleteImageAsync(string publicId)
        {
            if (string.IsNullOrEmpty(publicId)) return false;

            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result.Result == "ok";
        }
    }
}