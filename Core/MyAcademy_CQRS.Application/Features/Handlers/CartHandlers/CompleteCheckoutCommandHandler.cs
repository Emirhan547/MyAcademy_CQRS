using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Identities;

using MyAcademy_CQRS.Application.Features.Commands.CartCommands;
using MyAcademy_CQRS.Domain.Enums;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.OrderCommands;
using MyAcademyCQRS.Core.Application.Features.Commands.OrderItemCommands;
using MyAcademyCQRS.Core.Application.Features.Queries.CartQueries;

namespace MyAcademy_CQRS.Application.Features.Handlers.CartHandlers;

public class CompleteCheckoutCommandHandler(
    IMediator mediator,
    ICurrentUserService currentUserService,
    IValidator<CompleteCheckoutCommand> validator)
    : IRequestHandler<CompleteCheckoutCommand, Result>
{
    public async Task<Result> Handle(CompleteCheckoutCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Failure(validationResult.Errors.First().ErrorMessage);
        }

        var paymentValidationResult = ValidatePayment(request);
        if (!paymentValidationResult.Success)
        {
            return paymentValidationResult;
        }

        var cartResult = await mediator.Send(new GetCartQuery(), cancellationToken);
        if (!((BaseResult)cartResult).Success ||
      cartResult.Data?.Items == null ||
      !cartResult.Data.Items.Any())


        {
            return Result.Failure("Sepetiniz boş.");
        }

        var userId = currentUserService.GetUserId();
        if (string.IsNullOrWhiteSpace(userId))
        {
            return Result.Failure("Sipariş oluşturmak için giriş yapmalısınız.");
        }

        var orderResult = await mediator.Send(new CreateOrderCommand
        {
            UserId = userId,
            Items = cartResult.Data.Items.Select(x => new CreateOrderItemCommand
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList()
        }, cancellationToken);

        if (!orderResult.Success)
        {
            return Result.Failure(orderResult.Message);
        }

        await mediator.Send(new ClearCartCommand(), cancellationToken);
        return Result.SuccessResult("Ödeme alındı ve siparişiniz oluşturuldu.");
    }

    private static Result ValidatePayment(CompleteCheckoutCommand request)
    {
        return request.PaymentMethod switch
        {
            PaymentMethodType.CreditCard => ValidateCreditCard(request),
            PaymentMethodType.BankTransfer => ValidateBankTransfer(request),
            PaymentMethodType.CashOnDelivery => Result.SuccessResult(),
            _ => Result.Failure("Geçersiz ödeme yöntemi seçildi.")
        };
    }

    private static Result ValidateCreditCard(CompleteCheckoutCommand request)
    {
        if (string.IsNullOrWhiteSpace(request.CardHolderName))
        {
            return Result.Failure("Kart sahibi adı zorunludur.");
        }

        if (string.IsNullOrWhiteSpace(request.CardNumber) || request.CardNumber.Replace(" ", string.Empty).Length < 12)
        {
            return Result.Failure("Kart numarası geçerli değil.");
        }

        if (string.IsNullOrWhiteSpace(request.Cvv) || request.Cvv.Length < 3)
        {
            return Result.Failure("CVV bilgisi geçerli değil.");
        }

        return Result.SuccessResult();
    }

    private static Result ValidateBankTransfer(CompleteCheckoutCommand request)
    {
        if (string.IsNullOrWhiteSpace(request.Iban) || request.Iban.Replace(" ", string.Empty).Length < 10)
        {
            return Result.Failure("IBAN bilgisi geçerli değil.");
        }

        if (string.IsNullOrWhiteSpace(request.TransferReference))
        {
            return Result.Failure("Transfer referansı zorunludur.");
        }

        return Result.SuccessResult();
    }
}
