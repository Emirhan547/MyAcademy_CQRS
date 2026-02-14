using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.OrderQueries;
using MyAcademyCQRS.Core.Application.Features.Results.OrderResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers
{
    public class GetAllOrdersQueryHandler(
         IRepository<Order> _orderRepository,
         IMapper _mapper)
         : IRequestHandler<GetAllOrdersQuery, IList<GetAllOrdersQueryResult>>
    {
        public async Task<IList<GetAllOrdersQueryResult>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IList<GetAllOrdersQueryResult>>(orders);
        }
    }
}
