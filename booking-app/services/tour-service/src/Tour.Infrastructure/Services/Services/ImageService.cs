using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Shared.Common;
using Shared.Infrastructure;
using Application.Common;

namespace Infrastructure.Services
{
    public class ImageService : IImageService
    {
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IImageRepository _imageRepository;

        public ImageService(
            ICloudinaryService cloudinaryService, 
            IImageRepository imageRepository)
        {
            _cloudinaryService = cloudinaryService;
            _imageRepository = imageRepository;
        }

        public async Task<OperationResult<List<string>>> ProcessAndSaveImagesAsync(List<IFormFile> files, 
                    int travel_tour_id, string code_tour,string user_id)
        {
            if (files == null || !files.Any())
            {
                return OperationResult<List<string>>.Success(new List<string>(), "Không có tệp nào để xử lý.");
            }

            var uploadedPublicIds = new List<string>();
            var imageUrls = new List<string>();
            var imageEntities = new List<Image>();

            try
            {
                foreach (var file in files)
                {
                    var uploadResult = await _cloudinaryService.UploadImageAsync(file, $"Tours/{code_tour}");
                    
                    if (uploadResult.IsSuccess)
                    {
                        uploadedPublicIds.Add(uploadResult.PublicId);
                        imageUrls.Add(uploadResult.Url);

                        imageEntities.Add(new Image
                        {
                            travel_tour_id = travel_tour_id,
                            url = uploadResult.Url,
                            public_id = uploadResult.PublicId,
                            created_by = user_id,
                            created_date = DateTime.Now 
                        });
                    }
                }

                if (!imageEntities.Any())
                {
                    return OperationResult<List<string>>.Failure("Tải ảnh lên thất bại.");
                }

                await _imageRepository.AddRangeAsync(imageEntities);
                //await _imageRepository.SaveChangesAsync();

                return OperationResult<List<string>>.Success(imageUrls, "Xử lý hình ảnh thành công.");
            }
            catch (Exception ex)
            {
                if (uploadedPublicIds.Any())
                {
                    await _cloudinaryService.DeleteImagesAsync(uploadedPublicIds);
                }
                return OperationResult<List<string>>.Failure($"Lỗi hệ thống khi xử lý ảnh: {ex.Message}");
            }
        }
    }
}