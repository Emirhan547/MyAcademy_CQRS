using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactInfoCommands;

namespace MyAcademyCQRS.Core.Application.Validators.ContactInfoValidators
{
    public class UpdateContactInfoCommandValidator : AbstractValidator<UpdateContactInfoCommand>
    {
        public UpdateContactInfoCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.BackgroundImageUrl).NotEmpty().When(x => x.File is null);
            RuleFor(x => x.Address).NotEmpty().MaximumLength(300);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.OpeningHours).NotEmpty();
            RuleFor(x => x.HolidayHours).NotEmpty();
        }
    }
}