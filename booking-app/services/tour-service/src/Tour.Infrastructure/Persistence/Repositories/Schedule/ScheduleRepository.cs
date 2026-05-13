using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence;

namespace Infrastructure.Persistence
{
    public class ScheduleRepository: GenericRepository<Schedule, TourDbContext>, IScheduleRepository
    {
        public ScheduleRepository(TourDbContext context) : base(context) { }

        public async Task<Schedule> GetScheduleWithDetailsAsync(int id)
        {
            return await _context.Schedules.FirstOrDefaultAsync(t => t.id == id);
        }
    }
}