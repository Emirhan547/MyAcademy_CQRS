using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Core.Application.Features.Queries.GalleryCategoryQueries;
using MyAcademyCQRS.Core.Application.Features.Results.GalleryCategoryResults;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.GalleryCategoryHandlers
{
    public class GetGalleryCategoryByIdQueryHandler(
    AppDbContext _context,
    IMapper _mapper)
    : IRequestHandler<GetGalleryCategoryByIdQuery, GetGalleryCategoryByIdQueryResult>
    {
        public async Task<GetGalleryCategoryByIdQueryResult> Handle(
            GetGalleryCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var data = await _context.GalleryCategories
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return data is null
                ? null
                : _mapper.Map<GetGalleryCategoryByIdQueryResult>(data);
        }
    }

}
