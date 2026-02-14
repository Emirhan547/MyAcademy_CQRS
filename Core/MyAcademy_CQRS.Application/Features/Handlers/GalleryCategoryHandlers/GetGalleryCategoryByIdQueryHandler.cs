using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.GalleryCategoryQueries;
using MyAcademyCQRS.Core.Application.Features.Results.GalleryCategoryResults;


namespace MyAcademyCQRS.Core.Application.Features.Handlers.GalleryCategoryHandlers
{
    public class GetGalleryCategoryByIdQueryHandler(
   IGalleryCategoryReadRepository _galleryCategoryReadRepository,
    IMapper _mapper)
    : IRequestHandler<GetGalleryCategoryByIdQuery, GetGalleryCategoryByIdQueryResult>
    {
        public async Task<GetGalleryCategoryByIdQueryResult> Handle(
            GetGalleryCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var data = await _galleryCategoryReadRepository.GetByIdWithImagesAsync(request.Id, cancellationToken);

            return data is null
                ? null
                : _mapper.Map<GetGalleryCategoryByIdQueryResult>(data);
        }
    }

}
