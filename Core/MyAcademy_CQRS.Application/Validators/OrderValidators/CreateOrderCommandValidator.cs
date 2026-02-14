using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.OrderCommands;

namespace MyAcademyCQRS.Core.Application.Validators.OrderValidators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Items)
                .NotNull().WithMessage("Sipariş kalemleri zorunludur")
                .Must(x => x.Any()).WithMessage("En az 1 ürün seçmelisiniz");

            RuleForEach(x => x.Items).ChildRules(item =>
            {
                item.RuleFor(i => i.ProductId)
                    .GreaterThan(0).WithMessage("Geçerli bir ProductId gereklidir");

                item.RuleFor(i => i.Quantity)
                    .GreaterThan(0).WithMessage("Quantity 0'dan büyük olmalıdır");
            });
        }
    }
}
