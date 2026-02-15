
using MyAcademyCQRS.Core.Domain.Events;

namespace MyAcademyCQRS.Core.Domain.Events.OrderEvents
{
    public record OrderCreatedEvent(int OrderId) : IDomainEvent;
}