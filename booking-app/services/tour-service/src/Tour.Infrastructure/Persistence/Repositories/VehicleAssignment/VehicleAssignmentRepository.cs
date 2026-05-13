using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence;

namespace Infrastructure.Persistence
{
    public class VehicleAssignmentRepository : GenericRepository<VehicleAssignment, TourDbContext>, IVehicleAssignmentRepository
    {
        public VehicleAssignmentRepository(TourDbContext context) : base(context) { }

        public async Task<VehicleAssignment> GetVehicleAssignmentWithDetailsAsync(int id)
        {
            return await _context.VehicleAssignments.FirstOrDefaultAsync(t => t.id == id);
        }
    }
}