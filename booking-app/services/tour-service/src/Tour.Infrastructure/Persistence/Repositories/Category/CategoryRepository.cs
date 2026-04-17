using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence;

namespace Infrastructure.Persistence
{
    public class CategoryRepository : GenericRepository<Category, TourDbContext>, ICategoryRepository
    {
        public CategoryRepository(TourDbContext context) : base(context) { }

        public async Task<Category> GetCategoryWithDetailsAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(t => t.id == id);
        }
    }
}