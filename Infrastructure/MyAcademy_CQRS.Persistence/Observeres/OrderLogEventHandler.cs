using Microsoft.Extensions.Logging;
using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademy_CQRS.Application.Contracts.Services;
using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Core.Domain.Events.OrderEvents;

namespace MyAcademyCQRS.Infrastructure.Observeres
{
    public class OrderLogEventHandler(ILogger<OrderLogEventHandler> logger, IActivityLogService activityLogService) :
          IDomainEventHandler<OrderCreatedEvent>,
         IDomainEventHandler<OrderStatusChangedEvent>
    {
        public async Task HandleAsync(OrderCreatedEvent @event, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Order created. OrderId: {OrderId}", @event.OrderId);
            await activityLogService.LogAsync(ActivityLogCategory.Order, "Sipariş oluşturuldu", $"OrderId: {@event.OrderId}", cancellationToken: cancellationToken);
        }

        public async Task HandleAsync(OrderStatusChangedEvent @event, CancellationToken cancellationToken = default)
        {
            logger.LogInformation(
                "Order status changed. OrderId: {OrderId}, NewStatus: {NewStatus}",
                @event.OrderId,
                @event.NewStatus);
            await activityLogService.LogAsync(ActivityLogCategory.Order, "Sipariş durumu değişti", $"OrderId: {@event.OrderId}, NewStatus: {@event.NewStatus}", cancellationToken: cancellationToken);
        }
    }
}