using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.ProductResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.ProductQueries
{
    public class GetAllProductsQuery
          : IRequest<IList<GetAllProductsQueryResult>>
    {
    }
}
