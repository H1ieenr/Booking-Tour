using Microsoft.AspNetCore.Http;
using Shared.Common;

namespace Application.Features
{
    public class CategoryItemDTO
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public string? image { get; set; }
        public int? sequence { get; set; }
        public bool active { get; set; }
        public DateTime? created_date { get; set; }
    }
    #region GetCategoriesLookup
    public class GetCategoriesLookupDTO
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public string? image { get; set; }
        public int? sequence { get; set; }
    }
    #region GetCategoriesLookup
    public class GetCategoriesLookupRequestDTO
    {
        public string? search_text { get; set; } = "";
    };
    #endregion
    #endregion
    #region GetCategories
    public class GetCategoriesRequestDTO : PaginationParams
    {
        public string? search_text { get; set; } = "";
        public bool? is_active { get; set; }
    };
    #endregion
    #region CreateCategory
    public class CreateCategoryRequestDTO : BaseRequestDTO
    {
        public string name { get; set; } = "";
        public IFormFile? image { get; set; }
        public int? sequence { get; set; }
    }
    #endregion
    #region UpdateCategory
    public class UpdateCategoryRequestDTO : CreateCategoryRequestDTO
    {
        public int id { get; set; }
    }
    #endregion
    #region DeleteCategory
    public class DeleteCategoryRequestDTO : BaseRequestDTO
    {
        public int id { get; set; }
    }
    #endregion
    #region GetCategoryById
    public class GetCategoryByIdRequestDTO
    {
        public int id { get; set; }
    }
    public class GetCategoryByIdDTO : CategoryItemDTO
    {

    }
    #endregion
}