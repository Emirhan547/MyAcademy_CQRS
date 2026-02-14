using FluentValidation;
using MyAcademy_CQRS.Application.Features.Commands.CartCommands;


namespace MyAcademyCQRS.Core.Application.Validators.CartValidators
{
    public class AddToCartCommandValidator : AbstractValidator<AddToCartCommand>
    {
        public AddToCartCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Geçerli bir ürün seçiniz.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Adet 0'dan büyük olmalıdır.");
        }
    }
}