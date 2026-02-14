using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.ServiceCommands;

namespace MyAcademyCQRS.Core.Application.Validators.ServiceValidators
{
    public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);

            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Icon)
                .NotEmpty();
        }
    }
}
