using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.GalleryCategoryCommands;

namespace MyAcademyCQRS.Core.Application.Validators.GalleryCategoryValidators
{
    public class CreateGalleryCategoryCommandValidator
      : AbstractValidator<CreateGalleryCategoryCommand>
    {
        public CreateGalleryCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}