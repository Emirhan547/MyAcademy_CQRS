

using MyAcademyCQRS.Core.Domain.Events;

namespace MyAcademyCQRS.Core.Domain.Enums
{
    public record OrderStatusChangedEvent(int OrderId, OrderStatus NewStatus) : IDomainEvent;
}
