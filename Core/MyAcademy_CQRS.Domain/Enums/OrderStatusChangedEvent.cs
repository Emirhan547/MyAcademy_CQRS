

using MyAcademy_CQRS.Application.Contracts.Events;

namespace MyAcademyCQRS.Core.Domain.Enums
{
    public record OrderStatusChangedEvent(int OrderId, OrderStatus NewStatus) : IDomainEvent;
}
