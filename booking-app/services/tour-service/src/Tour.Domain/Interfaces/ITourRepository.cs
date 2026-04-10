using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITourRepository
    {
        Task<TravelTour> AddAsync(TravelTour tour);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}