using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VehicleAssignment
    {
        public int Id { get; set; }
        public int DepartureId { get; set; }
        public Departure? Departure { get; set; }
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        
        public DateTime FromDate { get; set; } 
        public DateTime ToDate { get; set; }
        
        public string Note { get; set; } = string.Empty; 
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        public bool IsDeleted {get; set;}
        public string CreatedDate {get; set;} = string.Empty;
        public string CreatedBy {get; set;} = string.Empty;
        public string? UpdatedBy {get; set;} = string.Empty;
        public DateTime? UpdatedDate { get; set; } 
    }
}