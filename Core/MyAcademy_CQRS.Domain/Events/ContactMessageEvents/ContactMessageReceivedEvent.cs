
using MyAcademyCQRS.Core.Domain.Events;

namespace MyAcademyCQRS.Core.Domain.Events.ContactMessageEvents
{
    public record ContactMessageReceivedEvent(int ContactMessageId, string Name, string Email, string Subject) : IDomainEvent;
}