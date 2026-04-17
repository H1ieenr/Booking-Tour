
namespace Domain.Entities
{
    public class TravelTour
    {
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public string code_tour { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;

        public decimal base_price { get; set; } 
        public bool is_preferred { get; set; }
        public int operator_id { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;

        public int total_days { get; set; }
        public int total_nights { get; set; }

        public string vehicle_description { get; set; } = string.Empty; 

        // --- CHI TIẾT ĐIỀU KHOẢN & DỊCH VỤ ---
        public string includes { get; set; } = string.Empty;    
        public string excludes { get; set; } = string.Empty;
        public string terms_and_conditions { get; set; } = string.Empty; 
        public string cancel_policy { get; set; } = string.Empty;      

        public bool active { get; set; }

        public bool is_deleted {get; set;}
        public DateTime? created_date {get; set;}
        public string created_by {get; set;} = string.Empty;
        public string? updated_by {get; set;} = string.Empty;
        public DateTime? updated_date { get; set; } 

        public int category_id { get; set; }
        public Category? category { get; set; }
        public ICollection<Image> images { get; set; } = new List<Image>();
        public ICollection<Schedule> schedules { get; set; } = new List<Schedule>();
        public ICollection<Departure> departures { get; set; } = new List<Departure>();
    }
}