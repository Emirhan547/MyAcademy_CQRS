using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Core.Domain.Events.OrderEvents;

namespace MyAcademyCQRS.Infrastructure.Observeres
{
    public class OrderLogEventHandler(ILogger<OrderLogEventHandler> logger) :
         IDomainEventHandler<OrderCreatedEvent>,
         IDomainEventHandler<OrderStatusChangedEvent>
    {
        public Task HandleAsync(OrderCreatedEvent @event, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Order created. OrderId: {OrderId}", @event.OrderId);
            return Task.CompletedTask;
        }

        public Task HandleAsync(OrderStatusChangedEvent @event, CancellationToken cancellationToken = default)
        {
            logger.LogInformation(
                "Order status changed. OrderId: {OrderId}, NewStatus: {NewStatus}",
                @event.OrderId,
                @event.NewStatus);
            return Task.CompletedTask;
        }
    }
}