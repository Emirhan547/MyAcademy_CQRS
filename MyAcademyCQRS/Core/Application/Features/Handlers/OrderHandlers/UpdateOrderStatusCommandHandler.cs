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
    public class UpdateOrderStatusCommandHandler(
        IRepository<Order> _repository,
        IUnitOfWork _unitOfWork,
        IValidator<UpdateOrderStatusCommand> _validator,
        IEnumerable<IOrderEventHandler> _eventHandlers)
        : IRequestHandler<UpdateOrderStatusCommand, Result>
    {
        public async Task<Result> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            // 1️⃣ Validation
            var vr = await _validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            // 2️⃣ Order getir
            var order = await _repository.GetByIdAsync(request.OrderId);
            if (order is null)
                return Result.Failure("Sipariş bulunamadı");

            await using var tx = await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 3️⃣ Status güncelle
                order.Status = request.Status;
                _repository.Update(order);

                var saved = await _unitOfWork.SaveChangesAsync();
                if (!saved)
                {
                    await tx.RollbackAsync();
                    return Result.Failure("Sipariş durumu güncellenemedi");
                }

                await tx.CommitAsync();

                // 🔔 EVENTLER COMMIT SONRASI
                var evt = new OrderStatusChangedEvent(order.Id, order.Status);
                foreach (var handler in _eventHandlers)
                {
                    await handler.OnOrderStatusChangedAsync(evt);
                }

                return Result.SuccessResult("Sipariş durumu güncellendi");
            }
            catch
            {
                await tx.RollbackAsync();
                return Result.Failure("Sipariş durumu güncellenirken hata oluştu");
            }
        }
    }
}
