
namespace Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public int TourId { get; set; }
        public Tour? Tour { get; set; }

        public bool IsDeleted {get; set;}
        public string CreatedDate {get; set;} = string.Empty;
        public string CreatedBy {get; set;} = string.Empty;
        public string? UpdatedBy {get; set;} = string.Empty;
        public DateTime? UpdatedDate { get; set; } 
    }
}