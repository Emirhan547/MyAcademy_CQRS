using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.TestimonialCommands;

namespace MyAcademyCQRS.Core.Application.Validators.TestimonialValidators
{
    public class CreateTestimonialCommandValidator
         : AbstractValidator<CreateTestimonialCommand>
    {
        public CreateTestimonialCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Ad soyad zorunludur")
                .MaximumLength(100);

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Rol zorunludur")
                .MaximumLength(100);

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Yorum zorunludur")
                .MaximumLength(500);
        }
    }
}
