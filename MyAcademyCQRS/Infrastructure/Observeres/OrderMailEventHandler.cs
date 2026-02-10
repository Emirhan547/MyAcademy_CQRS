using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Core.Domain.Events.OrderEvents;

namespace MyAcademyCQRS.Infrastructure.Observeres
{
    public class OrderMailEventHandler : IOrderEventHandler
    {
        public Task OnOrderCreatedAsync(OrderCreatedEvent @event)
        {
            // Mail gönderimi (stub)
            return Task.CompletedTask;
        }

        public Task OnOrderStatusChangedAsync(OrderStatusChangedEvent @event)
        {
            // Status değişim maili
            return Task.CompletedTask;
        }
    }
}
