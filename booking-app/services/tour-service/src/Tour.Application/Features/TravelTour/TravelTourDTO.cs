
namespace Application.Features
{
    public record TravelTourItemDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string code { get; set; }
        public string categoryName { get; set; }
        public decimal base_price { get; set; }
    };
    #region CreateTravelTour
    public record CreateTravelTourRequestDTO
    {
        public string title {get; set;}
        public string code_tour { get; set; } 
        public string description { get; set; } 
        public string location { get; set; } 
        public decimal base_price { get; set; } 
        public bool is_preferred { get; set; }
        public int operator_id { get; set; }
        public int total_days { get; set; }
        public int total_nights { get; set; }
        public string vehicle_description { get; set; }  

        public string includes { get; set; } = string.Empty;    
        public string excludes { get; set; } = string.Empty;
        public string terms_and_conditions { get; set; } = string.Empty; 
        public string cancel_policy { get; set; } = string.Empty; 

        public int category_id {get; set;}
    };
    #endregion
    #region UpdateTravelTour
    public record UpdateTravelTourRequestDTO : CreateTravelTourRequestDTO
    {
        public int id {get; set;}
    }
    #endregion
    #region GetTravelTourById
    public record GetTravelTourByIdRequestDTO
    {
        public int id {get; set;}
        public string? lang_id {get; set;}
        public int? user_id {get; set;}
    }
    public record GetTravelTourByIdDTO : TravelTourItemDTO
    {

    }
    #endregion
}