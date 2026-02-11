

using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler(IRepository<Product> _repository, IMapper _mapper, IUnitOfWork _unitOfWork, IValidator<UpdateProductCommand> _validator) : IRequestHandler<UpdateProductCommand, Result>
    {
        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var vr = await _validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid) return Result.Failure(vr.Errors.First().ErrorMessage);

            var product = await _repository.GetByIdAsync(request.Id);
            if (product is null) return Result.Failure("Ürün bulunamadı");

            _mapper.Map(request, product);
            _repository.Update(product);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Ürün güncellendi")
                : Result.Failure("Ürün güncellenemedi");
        }
    }
}
