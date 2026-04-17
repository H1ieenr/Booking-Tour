using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Vehicle
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;      
        public string license_plate { get; set; } = string.Empty; 
        public int capacity { get; set; }                     
        public string driver_name { get; set; } = string.Empty; 
        public string driver_phone { get; set; } = string.Empty;
        public VehicleStatus status { get; set; } = VehicleStatus.Active;
        public int current_odometer { get; set; }
        
        public ICollection<VehicleAssignment> assignments { get; set; } = new List<VehicleAssignment>();


        public bool is_deleted {get; set;}
        public DateTime? created_date {get; set;}
        public string created_by {get; set;} = string.Empty;
        public string? updated_by {get; set;} = string.Empty;
        public DateTime? updated_date { get; set; } 
    }
}