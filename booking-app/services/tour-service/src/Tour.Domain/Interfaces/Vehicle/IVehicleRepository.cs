using Domain.Entities;
using Shared.Persistence;

namespace Domain.Interfaces
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        Task<Vehicle> GetVehicleWithDetailsAsync(int id);
    }
}