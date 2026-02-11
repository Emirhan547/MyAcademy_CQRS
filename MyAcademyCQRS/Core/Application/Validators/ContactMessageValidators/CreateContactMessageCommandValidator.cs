using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactMessages;

namespace MyAcademyCQRS.Core.Application.Validators.ContactMessageValidators
{
    public class CreateContactMessageCommandValidator : AbstractValidator<CreateContactMessageCommand>
    {
        public CreateContactMessageCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Subject)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.Message)
                .NotEmpty()
                .MaximumLength(1000);
        }
    }
}
