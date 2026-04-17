using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Departure
    {
        public int id { get; set; }
        public DateTime start_date { get; set; } 
        public DateTime end_date { get; set; }  
        public int max_participants { get; set; } 
        public int current_participants { get; set; } 
        public DepartureStatus status { get; set; }


        public decimal adult_price { get; set; }     // Người lớn (>= 12 tuổi)
        public decimal child_price { get; set; }     // Trẻ em (5 - 11 tuổi)
        public decimal infant_price { get; set; } 

        public bool is_deleted {get; set;}
        public DateTime? created_date {get; set;}
        public string created_by {get; set;} = string.Empty;
        public string? updated_by {get; set;} = string.Empty;
        public DateTime? updated_date { get; set; } 

        public int travel_tour_id { get; set; }
        public TravelTour? travel_tour { get; set; }
        public ICollection<VehicleAssignment> vehicle_assignments { get; set; } = new List<VehicleAssignment>();
    }
}