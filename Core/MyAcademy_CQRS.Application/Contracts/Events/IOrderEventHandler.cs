using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Core.Domain.Events.OrderEvents;

namespace MyAcademy_CQRS.Application.Contracts.Events
{
    public interface IOrderEventHandler
    {
        Task OnOrderCreatedAsync(OrderCreatedEvent @event);
        Task OnOrderStatusChangedAsync(OrderStatusChangedEvent @event);
    }
}
