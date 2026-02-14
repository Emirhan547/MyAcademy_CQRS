using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademy_CQRS.Application.Contracts.Repositories
{
    public interface IGalleryCategoryReadRepository
    {
        Task<IList<GalleryCategory>> GetAllWithImagesAsync(CancellationToken cancellationToken);
        Task<IList<GalleryCategory>> GetActiveWithImagesAsync(CancellationToken cancellationToken);
        Task<GalleryCategory?> GetByIdWithImagesAsync(int id, CancellationToken cancellationToken);
    }
}
