using Microsoft.Extensions.Logging;
using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademyCQRS.Core.Domain.Events.ContactMessageEvents;

namespace MyAcademyCQRS.Infrastructure.Observeres
{
    public class ContactMessageEventLogHandler(ILogger<ContactMessageEventLogHandler> logger) :
        IDomainEventHandler<ContactMessageReceivedEvent>,
        IDomainEventHandler<ContactMessageUpdatedEvent>
    {
        public Task HandleAsync(ContactMessageReceivedEvent @event, CancellationToken cancellationToken = default)
        {
            logger.LogInformation(
                "Contact message received. ContactMessageId: {ContactMessageId}, Email: {Email}, Subject: {Subject}",
                @event.ContactMessageId,
                @event.Email,
                @event.Subject);
            return Task.CompletedTask;
        }

        public Task HandleAsync(ContactMessageUpdatedEvent @event, CancellationToken cancellationToken = default)
        {
            logger.LogInformation(
                "Contact message updated. ContactMessageId: {ContactMessageId}, Email: {Email}, Subject: {Subject}, IsActive: {IsActive}",
                @event.ContactMessageId,
                @event.Email,
                @event.Subject,
                @event.IsActive);
            return Task.CompletedTask;
        }
    }
}
