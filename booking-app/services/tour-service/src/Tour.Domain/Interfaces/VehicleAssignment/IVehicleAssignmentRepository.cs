using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IVehicleAssignmentRepository
    {
        Task<VehicleAssignment> GetVehicleAssignmentWithDetailsAsync(int id);
    }
}