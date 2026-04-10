
namespace Domain.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int DayNumber { get; set; } 
        public string Title { get; set; } = string.Empty; 
        public string MealOfTheDay {get; set;} = string.Empty;
        public string Content { get; set; } = string.Empty; 
        public int TourId { get; set; }
        public TravelTour? Tour { get; set; }

        public ICollection<VehicleAssignment> VehicleAssignments { get; set; } = new List<VehicleAssignment>();

        public bool IsDeleted {get; set;}
        public string CreatedDate {get; set;} = string.Empty;
        public string CreatedBy {get; set;} = string.Empty;
        public string? UpdatedBy {get; set;} = string.Empty;
        public DateTime? UpdatedDate { get; set; } 
    }
}