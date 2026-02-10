using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands;

namespace MyAcademyCQRS.Core.Application.Validators.ProductValidators
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir Product Id gereklidir");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün adı zorunludur")
                .MaximumLength(150).WithMessage("Ürün adı en fazla 150 karakter olabilir");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Ürün görseli zorunludur");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır");

            RuleFor(x => x.Rating)
                .InclusiveBetween(0, 5).WithMessage("Rating 0-5 arasında olmalıdır");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Geçerli bir CategoryId gereklidir");
        }
    }
}
