using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.CategoryCommands;

namespace MyAcademyCQRS.Core.Application.Validators.CategoryValidators
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı zorunludur")
                .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir");
        }
    }
}
