using Microsoft.AspNetCore.Http;
using Shared.Common;

namespace Application.Features
{
    public record CategoryItemDTO
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public string? image { get; set; }
        public int? sequence { get; set; }
        public bool active { get; set; }
        public DateTime? created_date { get; set; }
    }
    #region GetCategories
    public class GetCategoriesRequestDTO : PaginationParams
    {
        public string? search_text { get; set; } = "";
        public bool? is_active { get; set; }
    };
    #endregion
    #region CreateCategory
    public record CreateCategoryRequestDTO
    {
        public string name { get; set; } = "";
        public IFormFile? image { get; set; }
        public int? sequence { get; set; }
    };
    #endregion
    #region UpdateCategory
    public record UpdateCategoryRequestDTO : CreateCategoryRequestDTO
    {
        public int id { get; set; }
    }
    #endregion
    #region DeleteCategory
    public record DeleteCategoryRequestDTO
    {
        public int id { get; set; }
    }
    #endregion
    #region GetCategoryById
    public record GetCategoryByIdRequestDTO
    {
        public int id { get; set; }
    }
    public record GetCategoryByIdDTO : CategoryItemDTO
    {

    }
    #endregion
}