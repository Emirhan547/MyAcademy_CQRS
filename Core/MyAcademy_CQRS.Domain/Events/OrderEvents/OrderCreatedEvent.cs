using MyAcademyCQRS.Core.Application.Contracts;

namespace MyAcademyCQRS.Core.Domain.Events.OrderEvents
{
    public record OrderCreatedEvent(int OrderId) : IDomainEvent;
}