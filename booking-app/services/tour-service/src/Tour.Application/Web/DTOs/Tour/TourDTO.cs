using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tour.Application
{
    public class TourItemDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PricePerPerson { get; set; }
        public string Location { get; set; } = string.Empty;
        public int DurationDays { get; set; }
        public int CategoryId { get; set; }
    }
    public class CreateTourRequestDTO
    {
        //public Guid Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PricePerPerson { get; set; }
        public string Location { get; set; } = string.Empty;
        public int DurationDays { get; set; }
        public int CategoryId { get; set; }
    }
}