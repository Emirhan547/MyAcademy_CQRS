using MyAcademyCQRS.Core.Application.Contracts;

namespace MyAcademyCQRS.Core.Domain.Enums
{
    public record OrderStatusChangedEvent(int OrderId, OrderStatus NewStatus) : IDomainEvent;
}
