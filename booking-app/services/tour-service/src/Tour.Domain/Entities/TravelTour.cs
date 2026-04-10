
namespace Domain.Entities
{
    public class TravelTour
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CodeTour { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public decimal BasePrice { get; set; } 
        public bool IsPreferred { get; set; }
        public int OperatorId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int TotalDays { get; set; }
        public int TotalNights { get; set; }

        public string VehicleDescription { get; set; } = string.Empty; 

        // --- CHI TIẾT ĐIỀU KHOẢN & DỊCH VỤ ---
        public string Includes { get; set; } = string.Empty;    
        public string Excludes { get; set; } = string.Empty;
        public string TermsAndConditions { get; set; } = string.Empty; 
        public string CancelPolicy { get; set; } = string.Empty;      

        public bool IsDeleted {get; set;}
        public string CreatedDate {get; set;} = string.Empty;
        public string CreatedBy {get; set;} = string.Empty;
        public string? UpdatedBy {get; set;} = string.Empty;
        public DateTime? UpdatedDate { get; set; } 

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Image> Images { get; set; } = new List<Image>();
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        public ICollection<Departure> Departures { get; set; } = new List<Departure>();
    }
}