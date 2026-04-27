using Microsoft.AspNetCore.Http;
using Shared.Common;

namespace Application.Features
{
    public record ImageItemDTO
    {
        
    }
    #region UploadImages
    public record UploadImagesRequestDTO
    {
        public int travel_tour_id { get; set; }
        public string code_tour { get; set; }
        public bool is_primary { get; set; }
        public string? user_id {get; set;}
        public List<IFormFile> files { get; set; }
    }
    #endregion
}