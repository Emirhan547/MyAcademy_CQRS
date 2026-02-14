using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.OrderQueries;
using MyAcademyCQRS.Core.Application.Features.Results.OrderResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers
{
    public class GetOrderDetailQueryHandler(
        IOrderRepository _orderRepository,
        IMapper _mapper)
        : IRequestHandler<GetOrderDetailQuery, GetOrderDetailQueryResult>
    {
        public async Task<GetOrderDetailQueryResult?> Handle(
            GetOrderDetailQuery request,
            CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderWithItemsAsync(request.OrderId);
            if (order is null)
                return null;

            return _mapper.Map<GetOrderDetailQueryResult>(order);
        }
    }
}
