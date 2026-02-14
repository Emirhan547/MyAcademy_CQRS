namespace MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers.CreationChain
{
    public class FraudRuleControlStep : OrderCreationStepBase
    {
        protected override Task<bool> ProcessAsync(OrderCreationContext context, CancellationToken cancellationToken)
        {
            var totalQuantity = context.OrderItems.Sum(x => x.Quantity);
            if (totalQuantity > 100)
            {
                context.FailureReason = "Fraud/basic rule kontrolü başarısız: toplam ürün adedi limiti aşıldı.";
                return Task.FromResult(false);
            }

            if (context.TotalPrice > 100000)
            {
                context.FailureReason = "Fraud/basic rule kontrolü başarısız: sipariş tutarı limit üstünde.";
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}