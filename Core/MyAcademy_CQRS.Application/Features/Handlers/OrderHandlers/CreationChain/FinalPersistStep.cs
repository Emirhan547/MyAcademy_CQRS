using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers.CreationChain
{
    public class FinalPersistStep(IRepository<Order> orderRepository, IUnitOfWork unitOfWork) : OrderCreationStepBase
    {
        protected override async Task<bool> ProcessAsync(OrderCreationContext context, CancellationToken cancellationToken)
        {
            context.Order = new Order
            {
                OrderNumber = Guid.NewGuid().ToString("N")[..8],
                Status = OrderStatus.Pending,
                TotalPrice = context.TotalPrice,
                UserId = context.Command.UserId,
                OrderItems = context.OrderItems
            };

            await orderRepository.CreateAsync(context.Order);
            var saved = await unitOfWork.SaveChangesAsync();
            if (!saved)
            {
                context.FailureReason = "Sipariş kalıcı hale getirilemedi.";
                return false;
            }

            return true;
        }
    }
}
