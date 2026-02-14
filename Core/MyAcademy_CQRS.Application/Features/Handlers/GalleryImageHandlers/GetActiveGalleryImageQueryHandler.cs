using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Queries.GalleryImageQueries;
using MyAcademyCQRS.Core.Application.Features.Results.GalleryImages;



namespace MyAcademyCQRS.Core.Application.Features.Handlers.GalleryImageHandlers
{
    public class GetActiveGalleryImageQueryHandler(
          IGalleryCategoryReadRepository _galleryCategoryReadRepository,
          IMapper _mapper)
      : IRequestHandler<GetActiveGalleryImageQuery, IList<GetActiveGalleryImageQueryResult>>
    {
        public async Task<IList<GetActiveGalleryImageQueryResult>> Handle(
             GetActiveGalleryImageQuery request,
             CancellationToken cancellationToken)
        {
            var data = await _galleryCategoryReadRepository.GetActiveWithImagesAsync(cancellationToken);

            return _mapper.Map<IList<GetActiveGalleryImageQueryResult>>(data);
        }
    }
}
