using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence;

namespace Infrastructure.Persistence
{
    public class ImageRepository : GenericRepository<Image, TourDbContext>, IImageRepository
    {
        public ImageRepository(TourDbContext context) : base(context) { }

        // public async Task<Image> GetImageWithDetailsAsync(int id)
        // {
        //     return await _context.Images.FirstOrDefaultAsync(t => t.id == id);
        // }
    }
}