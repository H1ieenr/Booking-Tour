using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITourRepository
    {
        Task<Tour> AddAsync(Tour tour);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}