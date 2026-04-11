

namespace Domain.Entities
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public ICollection<TravelTour> travel_tours { get; set; } = new List<TravelTour>();

        public bool is_deleted {get; set;}
        public string created_date {get; set;} = string.Empty;
        public string created_By {get; set;} = string.Empty;
        public string? updated_by {get; set;} = string.Empty;
        public DateTime? updated_date { get; set; } 
    }
}