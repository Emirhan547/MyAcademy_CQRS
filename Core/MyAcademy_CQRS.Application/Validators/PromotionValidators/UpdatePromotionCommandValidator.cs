using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.PromotionCommands;

namespace MyAcademyCQRS.Core.Application.Validators.PromotionValidators
{
    public class UpdatePromotionCommandValidator:AbstractValidator<UpdatePromotionCommand>
    {
        public UpdatePromotionCommandValidator()
        {
            RuleFor(x => x.Title)
               .NotEmpty()
               .MaximumLength(150);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.DiscountPrice)
                .GreaterThan(0)
                .WithMessage("İndirim fiyatı 0'dan büyük olmalıdır");

            RuleFor(x => x.ExpireDate)
                .GreaterThan(DateTime.Now)
                .WithMessage("Bitiş tarihi bugünden büyük olmalıdır");
        }
    }
}
