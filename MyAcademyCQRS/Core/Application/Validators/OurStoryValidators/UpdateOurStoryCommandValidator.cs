using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.OurStoryCommands;

namespace MyAcademyCQRS.Core.Application.Validators.OurStoryValidators
{
    public class UpdateOurStoryCommandValidator:AbstractValidator<UpdateOurStoryCommand>
    {
        public UpdateOurStoryCommandValidator()
        {
            RuleFor(x => x.Title)
             .NotEmpty()
             .MaximumLength(150);

            RuleFor(x => x.Content)
                .NotEmpty()
                .MaximumLength(2000);

            RuleFor(x => x.ImageUrl)
                .NotEmpty();
        }
    }
}
