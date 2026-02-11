using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Core.Application.Features.Queries.GalleryCategoryQueries;
using MyAcademyCQRS.Core.Application.Features.Results.GalleryCategoryResults;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.GalleryCategoryHandlers
{
    public class GetAllGalleryCategoriesQueryHandler(
     AppDbContext _context,
     IMapper _mapper)
     : IRequestHandler<GetAllGalleryCategoriesQuery, IList<GetAllGalleryCategoriesQueryResult>>
    {
        public async Task<IList<GetAllGalleryCategoriesQueryResult>> Handle(
            GetAllGalleryCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var data = await _context.GalleryCategories
                .Include(x => x.Images)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IList<GetAllGalleryCategoriesQueryResult>>(data);
        }
    }

}
