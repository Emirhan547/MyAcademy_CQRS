using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers.CreationChain
{
    public class StockControlStep(IRepository<Product> productRepository) : OrderCreationStepBase
    {
        protected override async Task<bool> ProcessAsync(OrderCreationContext context, CancellationToken cancellationToken)
        {
            foreach (var item in context.Command.Items)
            {
                var product = await productRepository.GetByIdAsync(item.ProductId);
                if (product is null || !product.IsActive)
                {
                    context.FailureReason = $"Geçersiz veya pasif ürün bulundu. ProductId: {item.ProductId}";
                    return false;
                }

                if (item.Quantity > 20)
                {
                    context.FailureReason = $"Stok kontrolü başarısız. ProductId: {item.ProductId} için maksimum miktar 20 olabilir.";
                    return false;
                }

                context.OrderItems.Add(new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                });
            }

            return true;
        }
    }
}