

using MyAcademy_CQRS.Application.Contracts.Events;

namespace MyAcademyCQRS.Core.Domain.Events.ContactMessageEvents
{
    public record ContactMessageUpdatedEvent(int ContactMessageId, string Name, string Email, string Subject, bool IsActive) : IDomainEvent;
}