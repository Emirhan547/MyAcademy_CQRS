using Microsoft.Extensions.Logging;
using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademy_CQRS.Application.Contracts.Services;
using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Core.Domain.Events.PromotionEvents;

namespace MyAcademyCQRS.Infrastructure.Observeres
{
    public class PromotionEventLogHandler(ILogger<PromotionEventLogHandler> logger, IActivityLogService activityLogService) :
         IDomainEventHandler<PromotionCreatedEvent>,
        IDomainEventHandler<PromotionUpdatedEvent>
    {
        public async Task HandleAsync(PromotionCreatedEvent @event, CancellationToken cancellationToken = default)
        {
            logger.LogInformation(
                "Promotion created. PromotionId: {PromotionId}, Title: {Title}, Discount: {Discount}",
                @event.PromotionId,
                @event.Title,
                @event.DiscountRate);
            await activityLogService.LogAsync(ActivityLogCategory.Campaign, "Kampanya oluşturuldu", $"PromotionId: {@event.PromotionId}, Title: {@event.Title}, Discount: {@event.DiscountRate}", cancellationToken: cancellationToken);
        }

        public async Task HandleAsync(PromotionUpdatedEvent @event, CancellationToken cancellationToken = default)
        {
            logger.LogInformation(
                "Promotion updated. PromotionId: {PromotionId}, Title: {Title}, Discount: {Discount}, IsActive: {IsActive}",
                @event.PromotionId,
                @event.Title,
                @event.DiscountRate,
                @event.IsActive);
            await activityLogService.LogAsync(ActivityLogCategory.Campaign, "Kampanya güncellendi", $"PromotionId: {@event.PromotionId}, Title: {@event.Title}, Discount: {@event.DiscountRate}, IsActive: {@event.IsActive}", cancellationToken: cancellationToken);
        }
    }
}