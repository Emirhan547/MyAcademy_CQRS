using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.GalleryImageQueries;
using MyAcademyCQRS.Core.Application.Features.Results.GalleryImages;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.GalleryImageHandlers
{
    public class GetGalleryImageByIdQueryHandler(
     IRepository<GalleryImage> _repository,
     IMapper _mapper)
     : IRequestHandler<GetGalleryImageByIdQuery, GetGalleryImageByIdQueryResult>
    {
        public async Task<GetGalleryImageByIdQueryResult> Handle(
            GetGalleryImageByIdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            return entity is null
                ? null
                : _mapper.Map<GetGalleryImageByIdQueryResult>(entity);
        }
    }

}
