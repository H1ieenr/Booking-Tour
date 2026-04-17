using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VehicleAssignment
    {
        public int id { get; set; }
        public int departure_id { get; set; }
        public Departure? departure { get; set; }
        public int vehicle_id { get; set; }
        public Vehicle? vehicle { get; set; }
        
        public DateTime from_date { get; set; } 
        public DateTime to_date { get; set; }
        
        public string note { get; set; } = string.Empty; 
        public DateTime assigned_at { get; set; } = DateTime.UtcNow;

        public bool is_deleted {get; set;}
        public DateTime? created_date {get; set;}
        public string created_by {get; set;} = string.Empty;
        public string? updated_by {get; set;} = string.Empty;
        public DateTime? updated_date { get; set; } 
    }
}