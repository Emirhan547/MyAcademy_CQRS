using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactInfoCommands;

namespace MyAcademyCQRS.Core.Application.Validators.ContactInfoValidators
{
    public class CreateContactInfoCommandValidator : AbstractValidator<CreateContactInfoCommand>
    {
        public CreateContactInfoCommandValidator()
        {
            RuleFor(x => x.BackgroundImageUrl).NotEmpty();
            RuleFor(x => x.Address).NotEmpty().MaximumLength(300);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.OpeningHours).NotEmpty();
            RuleFor(x => x.HolidayHours).NotEmpty();
        }
    }
}