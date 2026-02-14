using FluentValidation;
using MyAcademy_CQRS.Application.Features.Commands.CartCommands;

namespace MyAcademyCQRS.Core.Application.Validators.CartValidators
{
    public class CompleteCheckoutCommandValidator : AbstractValidator<CompleteCheckoutCommand>
    {
        public CompleteCheckoutCommandValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Ad soyad zorunludur.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Geçerli e-posta giriniz.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres zorunludur.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir zorunludur.");
            RuleFor(x => x.District).NotEmpty().WithMessage("İlçe zorunludur.");
        }
    }
}