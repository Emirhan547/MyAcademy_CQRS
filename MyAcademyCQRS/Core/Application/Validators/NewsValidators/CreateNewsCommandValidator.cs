using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.NewsCommands;

namespace MyAcademyCQRS.Core.Application.Validators.NewsValidators
{
    public class CreateNewsCommandValidator : AbstractValidator<CreateNewsCommand>
    {
        public CreateNewsCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Summary).NotEmpty().MaximumLength(500);
            RuleFor(x => x.ImageUrl).NotEmpty();
            RuleFor(x => x.Category).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Author).NotEmpty().MaximumLength(100);
        }
    }
}