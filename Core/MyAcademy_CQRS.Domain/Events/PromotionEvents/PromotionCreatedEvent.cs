
using MyAcademy_CQRS.Application.Contracts.Events;

namespace MyAcademyCQRS.Core.Domain.Events.PromotionEvents
{
    public record PromotionCreatedEvent(int PromotionId, string Title, decimal DiscountRate) : IDomainEvent;
}