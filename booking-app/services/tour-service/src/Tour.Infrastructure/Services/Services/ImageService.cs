using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Shared.Common;
using Shared.Infrastructure;
using Application.Common;
using Application.Features;

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

        public async Task<OperationResult<List<UploadImageDTO>>> ProcessAndSaveImagesAsync(List<IFormFile> files,
                    int travel_tour_id, string code_tour, string user_id)
        {
            var results = new List<UploadImageDTO>();

            if (files == null || !files.Any())
            {
                return OperationResult<List<UploadImageDTO>>.Success(new List<UploadImageDTO>(), "Không có tệp nào để xử lý.");
            }

            var uploadedPublicIds = new List<string>();
            var imageEntities = new List<Image>();

            try
            {
                foreach (var file in files)
                {
                    var uploadResult = await _cloudinaryService.UploadImageAsync(file, $"Tours/{code_tour}");

                    if (uploadResult.IsSuccess)
                    {
                        uploadedPublicIds.Add(uploadResult.PublicId);

                        imageEntities.Add(new Image
                        {
                            travel_tour_id = travel_tour_id,
                            url = uploadResult.Url,
                            public_id = uploadResult.PublicId,
                            created_by = user_id,
                            created_date = DateTime.Now
                        });

                        results.Add(new UploadImageDTO
                        {
                            image_url = uploadResult.Url,
                            IsSuccess = true,
                            Message = "Upload thành công"
                        });
                    }
                    else
                    {
                        results.Add(new UploadImageDTO
                        {
                            image_url = "",
                            IsSuccess = false,
                            //Message = uploadResult.Message ?? "Upload thất bại"
                        });
                    }
                }

                if (!imageEntities.Any())
                {
                    return OperationResult<List<UploadImageDTO>>.Failure("Tải ảnh lên thất bại.");
                }

                await _imageRepository.AddRangeAsync(imageEntities);
                await _imageRepository.SaveChangesAsync();

                return OperationResult<List<UploadImageDTO>>.Success(results, "Xử lý hình ảnh thành công.");
            }
            catch (Exception ex)
            {
                if (uploadedPublicIds.Any())
                {
                    await _cloudinaryService.DeleteImagesAsync(uploadedPublicIds);
                }
                return OperationResult<List<UploadImageDTO>>.Failure($"Lỗi hệ thống khi xử lý ảnh: {ex.Message}");
            }
        }

        public async Task<OperationResult<List<DeleteImageDTO>>> DeleteImagesAsync(List<int> ids)
        {
            var results = new List<DeleteImageDTO>();

            var images = await _imageRepository.GetByIdsAsync(ids);

            var foundIds = images.Select(x => x.id).ToList();
            var notFoundIds = ids.Except(foundIds).ToList();

            var publicIds = images
                .Where(x => !string.IsNullOrEmpty(x.public_id))
                .Select(x => x.public_id)
                .ToList();

            try
            {
                if (publicIds.Any())
                {
                    await _cloudinaryService.DeleteImagesAsync(publicIds);
                }
                if (images.Any())
                {
                    _imageRepository.DeleteRange(images);
                    await _imageRepository.SaveChangesAsync();
                }
                results.AddRange(foundIds.Select(id => new DeleteImageDTO
                {
                    id = id,
                    IsSuccess = true,
                    Message = "Xoá thành công"
                }));
                results.AddRange(notFoundIds.Select(id => new DeleteImageDTO
                {
                    id = id,
                    IsSuccess = false,
                    Message = "Không tìm thấy ảnh"
                }));

                return OperationResult<List<DeleteImageDTO>>.Success(results);
            }
            catch (Exception ex)
            {
                return OperationResult<List<DeleteImageDTO>>.Failure($"Lỗi khi xoá ảnh: {ex.Message}");
            }
        }
    }
}