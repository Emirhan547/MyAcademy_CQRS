using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.OrderCommands;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Core.Domain.Events.OrderEvents;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler(
         IRepository<Order> _orderRepository,
         IRepository<Product> _productRepository,
         IUnitOfWork _unitOfWork,
         IValidator<CreateOrderCommand> _validator,
         IEnumerable<IOrderEventHandler> _eventHandlers)
         : IRequestHandler<CreateOrderCommand, Result>
    {
        public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // 1️⃣ Validation
            var vr = await _validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            await using var tx = await _unitOfWork.BeginTransactionAsync();

            try
            {
                var orderItems = new List<OrderItem>();
                decimal totalPrice = 0;

                // 2️⃣ Product doğrulama + fiyat hesaplama
                foreach (var item in request.Items)
                {
                    var product = await _productRepository.GetByIdAsync(item.ProductId);
                    if (product is null || !product.IsActive)
                    {
                        await tx.RollbackAsync();
                        return Result.Failure("Geçersiz veya pasif ürün bulundu");
                    }

                    var orderItem = new OrderItem
                    {
                        ProductId = product.Id,
                        Quantity = item.Quantity,
                        UnitPrice = product.Price
                    };

                    totalPrice += orderItem.UnitPrice * orderItem.Quantity;
                    orderItems.Add(orderItem);
                }

                // 3️⃣ Order oluştur
                var order = new Order
                {
                    OrderNumber = Guid.NewGuid().ToString("N")[..8],
                    Status = OrderStatus.Pending,
                    TotalPrice = totalPrice,
                    OrderItems = orderItems
                };

                await _orderRepository.CreateAsync(order);
                var saved = await _unitOfWork.SaveChangesAsync();

                if (!saved)
                {
                    await tx.RollbackAsync();
                    return Result.Failure("Sipariş oluşturulamadı");
                }

                await tx.CommitAsync();

                // 🔔 EVENTLER COMMIT SONRASI
                var evt = new OrderCreatedEvent(order.Id);
                foreach (var handler in _eventHandlers)
                {
                    await handler.OnOrderCreatedAsync(evt);
                }

                return Result.SuccessResult("Sipariş oluşturuldu");
            }
            catch
            {
                await tx.RollbackAsync();
                return Result.Failure("Sipariş oluşturulurken hata oluştu");
            }
        }
    }
}
