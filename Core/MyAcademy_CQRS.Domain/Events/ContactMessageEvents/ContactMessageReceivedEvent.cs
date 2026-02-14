using MyAcademyCQRS.Core.Application.Contracts;

namespace MyAcademyCQRS.Core.Domain.Events.ContactMessageEvents
{
    public record ContactMessageReceivedEvent(int ContactMessageId, string Name, string Email, string Subject) : IDomainEvent;
}