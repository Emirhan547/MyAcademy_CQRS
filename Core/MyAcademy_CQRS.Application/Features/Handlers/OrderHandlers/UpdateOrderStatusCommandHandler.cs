using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.OrderCommands;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Core.Domain.Enums;


namespace MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers
{
    public class UpdateOrderStatusCommandHandler(
      IRepository<Order> repository,
        IUnitOfWork unitOfWork,
        IValidator<UpdateOrderStatusCommand> validator,
        IDomainEventPublisher domainEventPublisher)
        : IRequestHandler<UpdateOrderStatusCommand, Result>
    {
        public async Task<Result> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            // 1️⃣ Validation
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            // 2️⃣ Order getir
            var order = await repository.GetByIdAsync(request.OrderId);
            if (order is null)
                return Result.Failure("Sipariş bulunamadı");

            await using var tx = await unitOfWork.BeginTransactionAsync();

            try
            {
                // 3️⃣ Status güncelle
                order.Status = request.Status;
                repository.Update(order);

                var saved = await unitOfWork.SaveChangesAsync();
                if (!saved)
                {
                    await tx.RollbackAsync(cancellationToken);
                    return Result.Failure("Sipariş durumu güncellenemedi");
                }

                await tx.CommitAsync(cancellationToken);

                // 🔔 EVENTLER COMMIT SONRASI
                await domainEventPublisher.PublishAsync(new OrderStatusChangedEvent(order.Id, order.Status), cancellationToken);

                return Result.SuccessResult("Sipariş durumu güncellendi");
            }
            catch
            {
                await tx.RollbackAsync(cancellationToken);
                return Result.Failure("Sipariş durumu güncellenirken hata oluştu");
            }
        }
    }
}
