using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.SliderCommands;

namespace MyAcademyCQRS.Core.Application.Validators
{
    public class SliderValidator : AbstractValidator<CreateSliderCommand>
    {
        public SliderValidator()
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

            RuleFor(x => x.BackgroundImageUrl)
                .NotEmpty()
                .WithMessage("Arka plan görseli zorunludur");

            RuleFor(x => x.ProductImageUrl)
                .NotEmpty()
                .WithMessage("Ürün görseli zorunludur");

            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Gösterim sırası 0 veya daha büyük olmalıdır");
        }
    }
}
