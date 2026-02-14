using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.SliderCommands;

namespace MyAcademyCQRS.Core.Application.Validators.SliderValidators
{
    public class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
    {
        public CreateSliderCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Slider başlığı zorunludur")
                .MaximumLength(100)
                .WithMessage("Slider başlığı en fazla 100 karakter olabilir");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Slider açıklaması zorunludur")
                .MaximumLength(500)
                .WithMessage("Slider açıklaması en fazla 500 karakter olabilir");

            RuleFor(x => x.BackgroundImageFile)
                  .NotNull()
                  .WithMessage("Arka plan görseli zorunludur");

            RuleFor(x => x.ProductImageFile)
                 .NotNull()
                 .WithMessage("Ürün görseli zorunludur");

            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Gösterim sırası 0 veya daha büyük olmalıdır");
        }
    }
}
