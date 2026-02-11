using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.GalleryCategoryResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.GalleryCategoryQueries
{
    public class GetAllGalleryCategoriesQuery
     : IRequest<IList<GetAllGalleryCategoriesQueryResult>>
    {
    }
}
