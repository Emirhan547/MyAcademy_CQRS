using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.GalleryCategoryCommands;

namespace MyAcademyCQRS.Core.Application.Validators.GalleryCategoryValidators
{
    public class UpdateGalleryCategoryCommandValidator
     : AbstractValidator<UpdateGalleryCategoryCommand>
    {
        public UpdateGalleryCategoryCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }

}
