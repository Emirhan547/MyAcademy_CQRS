using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.FeatureCommands;

namespace MyAcademyCQRS.Core.Application.Validators.FeatureValidators
{
    public class CreateCommandFeatureValidation:AbstractValidator<CreateFeatureCommand>
    {
        public CreateCommandFeatureValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Feature başlığı zorunludur")
                .MaximumLength(100)
                .WithMessage("Feature başlığı en fazla 100 karakter olabilir");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Feature açıklaması zorunludur")
                .MaximumLength(500)
                .WithMessage("Feature açıklaması en fazla 500 karakter olabilir");

            RuleFor(x => x.StepNumber)
                .GreaterThan(0)
                .WithMessage("StepNumber 0'dan büyük olmalıdır");
        }
    }
}
