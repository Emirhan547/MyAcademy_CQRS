using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Core.Domain.Events.OrderEvents;

namespace MyAcademyCQRS.Core.Application.Contracts
{
    public interface IOrderEventHandler
    {
        Task OnOrderCreatedAsync(OrderCreatedEvent @event);
        Task OnOrderStatusChangedAsync(OrderStatusChangedEvent @event);
    }
}
