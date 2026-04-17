using Domain.Entities;
using Shared.Persistence;

namespace Domain.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetCategoryWithDetailsAsync(int id);
    }
}