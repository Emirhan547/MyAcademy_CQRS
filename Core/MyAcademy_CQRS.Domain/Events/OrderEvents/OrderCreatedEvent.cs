
using MyAcademy_CQRS.Application.Contracts.Events;

namespace MyAcademyCQRS.Core.Domain.Events.OrderEvents
{
    public record OrderCreatedEvent(int OrderId) : IDomainEvent;
}