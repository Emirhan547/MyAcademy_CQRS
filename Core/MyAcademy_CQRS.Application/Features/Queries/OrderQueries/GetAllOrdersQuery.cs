using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.OrderResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.OrderQueries
{
    public class GetAllOrdersQuery : IRequest<IList<GetAllOrdersQueryResult>>
    {
    }
}
