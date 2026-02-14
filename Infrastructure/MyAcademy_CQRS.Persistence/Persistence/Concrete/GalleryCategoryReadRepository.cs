using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Infrastructure.Persistence.Concrete
{
    public class GalleryCategoryReadRepository(AppDbContext _context) : IGalleryCategoryReadRepository
    {
        public async Task<IList<GalleryCategory>> GetAllWithImagesAsync(CancellationToken cancellationToken)
        {
            return await _context.GalleryCategories
                .Include(x => x.Images)
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<GalleryCategory>> GetActiveWithImagesAsync(CancellationToken cancellationToken)
        {
            return await _context.GalleryCategories
                .Include(x => x.Images)
                .Where(x => x.IsActive)
                .ToListAsync(cancellationToken);
        }

        public async Task<GalleryCategory?> GetByIdWithImagesAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.GalleryCategories
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}