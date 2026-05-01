using Domain.Entities;
using Shared.Persistence;

namespace Domain.Interfaces
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        Task<List<Image>> GetByIdsAsync(List<int> ids);
    }
}