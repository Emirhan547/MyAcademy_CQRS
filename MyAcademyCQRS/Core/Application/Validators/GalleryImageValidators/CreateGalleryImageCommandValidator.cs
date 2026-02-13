using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.GalleryImageCommands;

namespace MyAcademyCQRS.Core.Application.Validators.GalleryImageValidators
{
    public class CreateGalleryImageCommandValidator : AbstractValidator<CreateGalleryImageCommand>
    {
        private const long MaxFileSizeInBytes = 5 * 1024 * 1024;

        private static readonly string[] AllowedContentTypes =
        {
            "image/jpeg",
            "image/jpg",
            "image/png",
            "image/webp"
        };
        public CreateGalleryImageCommandValidator()
        {
            RuleFor(x => x.GalleryCategoryId).GreaterThan(0);

            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.File)
                .NotNull().WithMessage("Dosya zorunludur")
                .Must(file => file!.Length > 0).WithMessage("Dosya boş olamaz")
                .Must(file => file!.Length <= MaxFileSizeInBytes)
                .WithMessage("Dosya boyutu en fazla 5 MB olabilir")
                .Must(file => AllowedContentTypes.Contains(file!.ContentType.ToLowerInvariant()))
                .WithMessage("Sadece JPG, PNG veya WEBP dosyaları yüklenebilir");

        }
    }
}
