using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademy_CQRS.Application.Features.Pipelines.OrderCreation;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.OrderCommands;


using MyAcademyCQRS.Core.Domain.Events.OrderEvents;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler(
        IUnitOfWork unitOfWork,
         IValidator<CreateOrderCommand> validator,
         IDomainEventPublisher domainEventPublisher,
         StockControlStep stockControlStep,
         PriceValidationStep priceValidationStep,
         PromotionApplyStep promotionApplyStep,
         FraudRuleControlStep fraudRuleControlStep,
         FinalPersistStep finalPersistStep)
         : IRequestHandler<CreateOrderCommand, Result>
    {
        public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // 1️⃣ Validation
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
            {
                return Result.Failure(vr.Errors.First().ErrorMessage);
            }
            await using var tx = await unitOfWork.BeginTransactionAsync();

            try
            {
                stockControlStep
                     .SetNext(priceValidationStep)
                     .SetNext(promotionApplyStep)
                     .SetNext(fraudRuleControlStep)
                     .SetNext(finalPersistStep);

                var context = new OrderCreationContext { Command = request };
                var chainResult = await stockControlStep.ExecuteAsync(context, cancellationToken);

                // 3️⃣ Order oluştur
                if (!chainResult)
                {
              
                    await tx.RollbackAsync(cancellationToken);
                    return Result.Failure(context.FailureReason ?? "Sipariş pipeline başarısız oldu.");
                }

              
                await tx.CommitAsync(cancellationToken);

                await domainEventPublisher.PublishAsync(new OrderCreatedEvent(context.Order!.Id), cancellationToken);

                return Result.SuccessResult("Sipariş oluşturuldu");
            }
            catch
            {
                await tx.RollbackAsync(cancellationToken);
                return Result.Failure("Sipariş oluşturulurken hata oluştu");
            }
        }
    }
}