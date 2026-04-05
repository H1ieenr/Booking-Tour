using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;      
        public string LicensePlate { get; set; } = string.Empty; 
        public int Capacity { get; set; }                     
        public string DriverName { get; set; } = string.Empty; 
        public string DriverPhone { get; set; } = string.Empty;
        public VehicleStatus Status { get; set; } = VehicleStatus.Active;
        public int CurrentOdometer { get; set; }
        
        public ICollection<VehicleAssignment> Assignments { get; set; } = new List<VehicleAssignment>();


        public bool IsDeleted {get; set;}
        public string CreatedDate {get; set;} = string.Empty;
        public string CreatedBy {get; set;} = string.Empty;
        public string? UpdatedBy {get; set;} = string.Empty;
        public DateTime? UpdatedDate { get; set; } 
    }
}