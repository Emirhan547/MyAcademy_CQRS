using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.GalleryCategoryQueries;
using MyAcademyCQRS.Core.Application.Features.Results.GalleryCategoryResults;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.GalleryCategoryHandlers
{
    public class GetAllGalleryCategoriesQueryHandler(
    IGalleryCategoryReadRepository _galleryCategoryReadRepository,
     IMapper _mapper)
     : IRequestHandler<GetAllGalleryCategoriesQuery, IList<GetAllGalleryCategoriesQueryResult>>
    {
        public async Task<IList<GetAllGalleryCategoriesQueryResult>> Handle(
            GetAllGalleryCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var data = await _galleryCategoryReadRepository.GetAllWithImagesAsync(cancellationToken);

            return _mapper.Map<IList<GetAllGalleryCategoriesQueryResult>>(data);
        }
    }

}
