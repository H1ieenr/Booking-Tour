using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence;

namespace Infrastructure.Persistence
{
    public class ImageRepository : GenericRepository<Image, TourDbContext>, IImageRepository
    {
        public ImageRepository(TourDbContext context) : base(context) { }

        public async Task<List<Image>> GetByIdsAsync(List<int> ids)
        {
            return await _context.Images.Where(t => ids.Contains(t.id)).ToListAsync();
        }
    }
}