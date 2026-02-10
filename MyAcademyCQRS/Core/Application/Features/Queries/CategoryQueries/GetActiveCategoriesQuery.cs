using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.CategoryResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.CategoryQueries
{
    public class GetActiveCategoriesQuery : IRequest<IList<GetActiveCategoriesQueryResult>>
    {
    }
}
