using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence;

namespace Infrastructure.Persistence
{
    public class VehicleRepository : GenericRepository<Vehicle, TourDbContext>, IVehicleRepository
    {
        public VehicleRepository(TourDbContext context) : base(context) { }

        public async Task<Vehicle> GetVehicleWithDetailsAsync(int id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(t => t.id == id);
        }
    }
}