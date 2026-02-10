using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Core.Domain.Events.OrderEvents;

namespace MyAcademyCQRS.Infrastructure.Observeres
{
    public class OrderLogEventHandler : IOrderEventHandler
    {
        public Task OnOrderCreatedAsync(OrderCreatedEvent @event)
        {
            Console.WriteLine($"[LOG] Order created -> {@event.OrderId}");
            return Task.CompletedTask;
        }

        public Task OnOrderStatusChangedAsync(OrderStatusChangedEvent @event)
        {
            Console.WriteLine($"[LOG] Order {@event.OrderId} status changed -> {@event.NewStatus}");
            return Task.CompletedTask;
        }
    }
}