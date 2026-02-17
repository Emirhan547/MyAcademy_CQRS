using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademy_CQRS.Application.Features.Pipelines.OrderCreation
{
    public class PromotionApplyStep(IRepository<Promotion> promotionRepository) : OrderCreationStepBase
    {
        protected override async Task<bool> ProcessAsync(OrderCreationContext context, CancellationToken cancellationToken)
        {
            var promotions = await promotionRepository.GetAllAsync();
            var activePromotion = promotions
                .Where(x => x.IsActive && x.ExpireDate >= DateTime.UtcNow)
                .OrderByDescending(x => x.DiscountPrice)
                .FirstOrDefault();

            if (activePromotion is not null)
            {
                context.DiscountAmount = activePromotion.DiscountPrice;
                context.TotalPrice = Math.Max(0, context.TotalPrice - activePromotion.DiscountPrice);
            }

            return true;
        }
    }
}