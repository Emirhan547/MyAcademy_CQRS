using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.GallerImageCommands;

namespace MyAcademyCQRS.Core.Application.Validators.GalleryImageValidators
{
    public class CreateGalleryImageCommandValidator : AbstractValidator<CreateGalleryImageCommand>
    {
        public CreateGalleryImageCommandValidator()
        {
            RuleFor(x => x.GalleryCategoryId).GreaterThan(0);

            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.ImageUrl)
                .NotEmpty();

        }
    }
}
