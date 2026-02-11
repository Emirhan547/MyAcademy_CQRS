using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.PromotionResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.PromotionQueries
{
    public class GetActivePromotionsQuery
        : IRequest<IList<GetActivePromotionsQueryResult>>
    {
    }
}
