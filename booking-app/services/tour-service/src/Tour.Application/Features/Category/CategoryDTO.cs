
namespace Application.Features
{
    public record CategoryItemDTO
    {

    }
    #region CreateCategory
    public record CreateCategoryRequestDTO
    {
        public string name { get; set; } = string.Empty;
        public string? image {get; set;} = string.Empty;
        public int? sequence { get; set; }
    };
    #endregion
    #region UpdateCategory
    public record UpdateCategoryRequestDTO : CreateCategoryRequestDTO
    {
        public int id { get; set; }
    }
    #endregion
    #region GetCategoryById
    public record GetCategoryByIdRequestDTO
    {
        public int id { get; set; }
        public int? user_id { get; set; }
    }
    public record GetCategoryByIdDTO : CategoryItemDTO
    {

    }
    #endregion
}