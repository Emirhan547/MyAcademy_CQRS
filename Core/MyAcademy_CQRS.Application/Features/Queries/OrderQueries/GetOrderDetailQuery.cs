using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.OrderResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.OrderQueries
{
    public class GetOrderDetailQuery : IRequest<GetOrderDetailQueryResult>
    {
        public int OrderId { get; set; }
    }
}
