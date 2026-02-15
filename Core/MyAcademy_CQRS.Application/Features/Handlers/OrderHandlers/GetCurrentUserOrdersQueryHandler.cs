using MediatR;
using MyAcademy_CQRS.Application.Contracts.Identities;

using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.OrderQueries;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers;

public class GetCurrentUserOrdersQueryHandler(
    IOrderRepository orderRepository,
    ICurrentUserService currentUserService) : IRequestHandler<GetCurrentUserOrdersQuery, IList<Order>>
{
    public async Task<IList<Order>> Handle(GetCurrentUserOrdersQuery request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.GetUserId();
        if (string.IsNullOrWhiteSpace(userId))
        {
            return [];
        }

        return await orderRepository.GetOrdersByUserIdWithItemsAsync(userId);
    }
}