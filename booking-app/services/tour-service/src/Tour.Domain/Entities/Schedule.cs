
namespace Domain.Entities
{
    public class Schedule
    {
        public int id { get; set; }
        public int day_number { get; set; } 
        public string title { get; set; } = string.Empty; 
        public string meal_of_the_day {get; set;} = string.Empty;
        public string content { get; set; } = string.Empty; 
        public int travel_tour_id { get; set; }
        public TravelTour? travel_tour { get; set; }

        public ICollection<VehicleAssignment> vehicle_assignments { get; set; } = new List<VehicleAssignment>();

        public bool is_deleted {get; set;}
        public DateTime? created_date {get; set;}
        public string created_by {get; set;} = string.Empty;
        public string? updated_by {get; set;} = string.Empty;
        public DateTime? updated_date { get; set; } 
    }
}