using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.ServiceCommands;

namespace MyAcademyCQRS.Core.Application.Validators.ServiceValidators
{
    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık zorunludur")
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama zorunludur")
                .MaximumLength(500);

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Icon zorunludur");
        }
    }
}
