

namespace Domain.Entities
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string? image { get; set; }
        public string? image_public_id { get; set; }
        public int? sequence { get; set; }
        public bool active { get; set; }
        public ICollection<TravelTour> travel_tours { get; set; } = new List<TravelTour>();

        public bool is_deleted { get; set; }
        public DateTime? created_date { get; set; }
        public string created_by { get; set; } = string.Empty;
        public string? updated_by { get; set; } = string.Empty;
        public DateTime? updated_date { get; set; }
    }
}