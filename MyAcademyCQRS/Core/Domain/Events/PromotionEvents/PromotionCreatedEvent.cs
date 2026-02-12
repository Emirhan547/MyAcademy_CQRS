using MyAcademyCQRS.Core.Application.Contracts;

namespace MyAcademyCQRS.Core.Domain.Events.PromotionEvents
{
    public record PromotionCreatedEvent(int PromotionId, string Title, decimal DiscountRate) : IDomainEvent;
}