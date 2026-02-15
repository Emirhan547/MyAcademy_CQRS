
using MyAcademyCQRS.Core.Domain.Events;

namespace MyAcademyCQRS.Core.Domain.Events.PromotionEvents
{
    public record PromotionUpdatedEvent(int PromotionId, string Title, decimal DiscountRate, bool IsActive) : IDomainEvent;
}