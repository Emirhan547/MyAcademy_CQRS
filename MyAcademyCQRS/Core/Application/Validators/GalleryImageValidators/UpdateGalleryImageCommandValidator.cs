using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.GallerImageCommands;

namespace MyAcademyCQRS.Core.Application.Validators.GalleryImageValidators
{
    public class UpdateGalleryImageCommandValidator
     : AbstractValidator<UpdateGalleryImageCommand>
    {
        public UpdateGalleryImageCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Title).NotEmpty().MaximumLength(150);
           
        }
    }

}
