using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Core.Application.Features.Queries.GalleryImageQueries;
using MyAcademyCQRS.Core.Application.Features.Results.GallerImages;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.GalleryImageHandlers
{
    public class GetActiveGalleryImageQueryHandler(AppDbContext _context,
    IMapper _mapper)
    : IRequestHandler<GetActiveGalleryImageQuery, IList<GetActiveGalleryImageQueryResult>>
    {
        public async Task<IList<GetActiveGalleryImageQueryResult>> Handle(GetActiveGalleryImageQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.GalleryCategories
              .Include(x => x.Images)
              .Where(x => x.IsActive)
              .ToListAsync(cancellationToken);

            return _mapper.Map<IList<GetActiveGalleryImageQueryResult>>(data);
        }
    }
}
