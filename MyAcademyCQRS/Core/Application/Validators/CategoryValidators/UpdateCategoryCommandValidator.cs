using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.CategoryCommands;

namespace MyAcademyCQRS.Core.Application.Validators.CreateValidators
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir Category Id gereklidir");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı zorunludur")
                .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir");
        }
    }
}
