using Microsoft.AspNetCore.Http;
using Shared.Common;

namespace Application.Features
{
    public record ImageItemDTO
    {

    }
    #region UpdateImages
    public record UpdateImagesRequestDTO
    {
        public UploadImagesRequestDTO uploads { get; set; } = new UploadImagesRequestDTO();
        public DeleteImagesRequestDTO deletes { get; set; } = new DeleteImagesRequestDTO();
    }

    public record UploadImagesRequestDTO
    {
        public int travel_tour_id { get; set; }
        public string code_tour { get; set; }
        public bool is_primary { get; set; }
        public string? user_id { get; set; } = "";
        public List<IFormFile> files { get; set; }
    }
    public record DeleteImagesRequestDTO
    {
        public List<int> delete_image_ids { get; set; } = new List<int>();
    }
    public class UpdateImagesDTO
    {
        public List<UploadImageDTO> new_image_urls { get; set; } = new List<UploadImageDTO>();
        public List<DeleteImageDTO> deleted_image_ids { get; set; } = new List<DeleteImageDTO>();
    }
    public record UploadImageDTO
    {
        public string image_url { get; set; } = "";
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = "";
    }
    public record DeleteImageDTO
    {
        public int id { get; set; } = 0;
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = "";
    }
    #endregion
    #region SetMainImage
    public record SetMainImageRequestDTO
    {
        public int id { get; set; }
        public bool is_primary { get; set; }
    }
    #endregion
}