using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands;
using MyAcademyCQRS.Core.Domain.Entities;


namespace MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler(IRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateProductCommand> validator, IImageStorageService imageStorage) : IRequestHandler<CreateProductCommand, Result>
    {
        public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var values = await validator.ValidateAsync(request, cancellationToken);
            if (!values.IsValid)
                return Result.Failure(values.Errors.First().ErrorMessage);
            var fileName = $"products/{Guid.NewGuid()}{Path.GetExtension(request.File.FileName)}";
            await using var stream = request.File.OpenReadStream();
            request.ImageUrl = await imageStorage.UploadAsync(stream, fileName, request.File.ContentType);

            var product = mapper.Map<Product>(request);
            await repository.CreateAsync(product);
            return await unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Ürün Eklendi") : Result.Failure("Ürün Eklenemedi");
        }
    }
}
