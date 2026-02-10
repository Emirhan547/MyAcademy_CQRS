

using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Infrastructure.Persistence.Context;
using NuGet.Protocol.Plugins;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler(IRepository<Product> _repository, IUnitOfWork _unitOfWork, IMapper _mapper, IValidator<CreateProductCommand> _validator) : IRequestHandler<CreateProductCommand, Result>
    {
        public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
           var values=await _validator.ValidateAsync(request,cancellationToken);
            if(!values.IsValid) 
                return Result.Failure(values.Errors.First().ErrorMessage);
            var product=_mapper.Map<Product>(request);
            await _repository.CreateAsync(product);
            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Ürün Eklendi") : Result.Failure("Ürün Eklenemedi");
        }
    }
}
