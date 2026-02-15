using Microsoft.Extensions.Logging;
using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Core.Domain.Events.OrderEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Infrastructure.Eventing
{
    public class OrderMailEventHandler(ILogger<OrderMailEventHandler> logger) :
             IDomainEventHandler<OrderCreatedEvent>,
             IDomainEventHandler<OrderStatusChangedEvent>
    {
        public Task HandleAsync(OrderCreatedEvent @event, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Order confirmation mail queued. OrderId: {OrderId}", @event.OrderId);
            return Task.CompletedTask;
        }

        public Task HandleAsync(OrderStatusChangedEvent @event, CancellationToken cancellationToken = default)
        {

            logger.LogInformation(
                "Order status notification mail queued. OrderId: {OrderId}, NewStatus: {NewStatus}",
                @event.OrderId,
                @event.NewStatus);
            return Task.CompletedTask;
        }
    }
}
