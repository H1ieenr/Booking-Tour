

namespace Tour.Application
{
    public record TravelTourItemDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string code { get; set; }
        public string categoryName { get; set; }
        public decimal base_price { get; set; }
    };
    #region GetTravelTourById
    public record CreateTravelTourRequestDto
    {
        public string title {get; set;}
        public int category_id {get; set;}
        public decimal price {get; set;}
    };
    #endregion
    #region GetTravelTourById
    public record GetTravelTourByIdRequestDTO
    {
        public int id {get; set;}
        public string? lang_id {get; set;}
        public int? user_id {get; set;}
    }
    public record GetTravelTourByIdDTO : TravelTourItemDto
    {

    }
    #endregion
}