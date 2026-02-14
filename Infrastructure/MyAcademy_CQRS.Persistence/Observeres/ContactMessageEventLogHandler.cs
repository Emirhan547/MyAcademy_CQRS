using Microsoft.Extensions.Logging;
using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademy_CQRS.Application.Contracts.Services;
using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Core.Domain.Events.ContactMessageEvents;

namespace MyAcademyCQRS.Infrastructure.Observeres
{
    public class ContactMessageEventLogHandler(ILogger<ContactMessageEventLogHandler> logger, IActivityLogService activityLogService) :
           IDomainEventHandler<ContactMessageReceivedEvent>,
        IDomainEventHandler<ContactMessageUpdatedEvent>
    {
        public async Task HandleAsync(ContactMessageReceivedEvent @event, CancellationToken cancellationToken = default)
        {
            logger.LogInformation(
                "Contact message received. ContactMessageId: {ContactMessageId}, Email: {Email}, Subject: {Subject}",
                @event.ContactMessageId,
                @event.Email,
                @event.Subject);
            await activityLogService.LogAsync(ActivityLogCategory.Contact, "İletişim mesajı alındı", $"ContactMessageId: {@event.ContactMessageId}, Email: {@event.Email}, Subject: {@event.Subject}", cancellationToken: cancellationToken);
        }

        public async Task HandleAsync(ContactMessageUpdatedEvent @event, CancellationToken cancellationToken = default)
        {
            logger.LogInformation(
                "Contact message updated. ContactMessageId: {ContactMessageId}, Email: {Email}, Subject: {Subject}, IsActive: {IsActive}",
                @event.ContactMessageId,
                @event.Email,
                @event.Subject,
                @event.IsActive);
            await activityLogService.LogAsync(ActivityLogCategory.Contact, "İletişim mesajı güncellendi", $"ContactMessageId: {@event.ContactMessageId}, Email: {@event.Email}, Subject: {@event.Subject}, IsActive: {@event.IsActive}", cancellationToken: cancellationToken);
        }
    }
}
