using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence;

namespace Infrastructure.Persistence
{
    public class TravelTourRepository : GenericRepository<TravelTour, TourDbContext>, ITravelTourRepository
    {
        public TravelTourRepository(TourDbContext context) : base(context) { }

        public async Task<TravelTour?> GetTourWithDetailsAsync(int id)
        {
            return await _context.TravelTours
                .Include(t => t.category)
                .Include(t => t.schedules)
                .Include(t => t.images)
                .Include(t => t.departures)
                .FirstOrDefaultAsync(t => t.id == id);
        }

        public async Task<IEnumerable<TravelTour>> GetTravelToursByCategoryAsync(int category_id)
        {
            return await _context.TravelTours
                .Where(t => t.category_id == category_id)
                .ToListAsync();
        }
    }
}