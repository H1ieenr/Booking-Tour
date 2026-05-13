using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence;

namespace Infrastructure.Persistence
{
    public class DepartureRepository : GenericRepository<Departure, TourDbContext>, IDepartureRepository
    {
        public DepartureRepository(TourDbContext context) : base(context) { }

        public async Task<Departure> GetDepartureWithDetailsAsync(int id)
        {
            return await _context.Departures.FirstOrDefaultAsync(t => t.id == id);
        }
    }
}