using Microsoft.Extensions.Logging;
using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademyCQRS.Core.Domain.Events.PromotionEvents;

namespace MyAcademyCQRS.Infrastructure.Observeres
{
    public class PromotionEventLogHandler(ILogger<PromotionEventLogHandler> logger) :
        IDomainEventHandler<PromotionCreatedEvent>,
        IDomainEventHandler<PromotionUpdatedEvent>
    {
        public Task HandleAsync(PromotionCreatedEvent @event, CancellationToken cancellationToken = default)
        {
            logger.LogInformation(
                "Promotion created. PromotionId: {PromotionId}, Title: {Title}, Discount: {Discount}",
                @event.PromotionId,
                @event.Title,
                @event.DiscountRate);
            return Task.CompletedTask;
        }

        public Task HandleAsync(PromotionUpdatedEvent @event, CancellationToken cancellationToken = default)
        {
            logger.LogInformation(
                "Promotion updated. PromotionId: {PromotionId}, Title: {Title}, Discount: {Discount}, IsActive: {IsActive}",
                @event.PromotionId,
                @event.Title,
                @event.DiscountRate,
                @event.IsActive);
            return Task.CompletedTask;
        }
    }
}