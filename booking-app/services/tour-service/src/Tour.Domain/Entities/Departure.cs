using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Departure
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }  
        public int MaxParticipants { get; set; } 
        public int CurrentParticipants { get; set; } 
        public DepartureStatus Status { get; set; }


        public decimal AdultPrice { get; set; }     // Người lớn (>= 12 tuổi)
        public decimal ChildPrice { get; set; }     // Trẻ em (5 - 11 tuổi)
        public decimal InfantPrice { get; set; } 

        public int TourId { get; set; }
        public Tour? Tour { get; set; }
        public ICollection<VehicleAssignment> VehicleAssignments { get; set; } = new List<VehicleAssignment>();
    }
}