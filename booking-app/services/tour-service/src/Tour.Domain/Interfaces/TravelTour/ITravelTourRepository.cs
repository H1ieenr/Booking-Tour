using Domain.Entities;
using Shared.Persistence;

namespace Domain.Interfaces
{
    public interface ITravelTourRepository : IGenericRepository<TravelTour> 
    {
        Task<TravelTour?> GetTourWithDetailsAsync(int id);
        Task<IEnumerable<TravelTour>> GetTravelToursByCategoryAsync(int category_id);
    }
}