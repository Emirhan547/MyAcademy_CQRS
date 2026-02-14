using FluentValidation;
using MyAcademyCQRS.Core.Application.Features.Commands.OrderCommands;

namespace MyAcademyCQRS.Core.Application.Validators.OrderValidators
{
    public class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>
    {
        public UpdateOrderStatusCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("Geçerli bir OrderId gereklidir");
        }
    }
}
