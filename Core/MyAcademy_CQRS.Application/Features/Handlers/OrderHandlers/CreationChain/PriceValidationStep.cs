namespace MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers.CreationChain
{
    public class PriceValidationStep : OrderCreationStepBase
    {
        protected override Task<bool> ProcessAsync(OrderCreationContext context, CancellationToken cancellationToken)
        {
            var total = context.OrderItems.Sum(x => x.UnitPrice * x.Quantity);
            if (total <= 0)
            {
                context.FailureReason = "Toplam tutar sıfır veya negatif olamaz.";
                return Task.FromResult(false);
            }

            context.TotalPrice = total;
            return Task.FromResult(true);
        }
    }
}