
namespace Domain.Entities
{
    public class Image
    {
        public int id { get; set; }
        public string url { get; set; } = string.Empty;
        public bool is_primary { get; set; }
        public int travel_tour_id { get; set; }
        public TravelTour? travel_tour { get; set; }

        public bool is_deleted {get; set;}
        public string created_date {get; set;} = string.Empty;
        public string created_by {get; set;} = string.Empty;
        public string? updated_by {get; set;} = string.Empty;
        public DateTime? updated_date { get; set; } 
    }
}