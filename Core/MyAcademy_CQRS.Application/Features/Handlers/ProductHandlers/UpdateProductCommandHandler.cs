

using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Common.Storage;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler(IRepository<Product> repository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<UpdateProductCommand> validator, IImageStorageService imageStorage) : IRequestHandler<UpdateProductCommand, Result>
    {
        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid) return Result.Failure(vr.Errors.First().ErrorMessage);

            var product = await repository.GetByIdAsync(request.Id);
            if (product is null) return Result.Failure("Ürün bulunamadı");

            if (request.File is not null && request.File.Length > 0)
            {
                var oldObjectName = ImageStoragePathHelper.GetObjectNameFromUrl(product.ImageUrl);
                if (!string.IsNullOrWhiteSpace(oldObjectName))
                {
                    await imageStorage.DeleteAsync(oldObjectName);
                }

                var fileName = $"products/{Guid.NewGuid()}{Path.GetExtension(request.File.FileName)}";
                await using var stream = request.File.OpenReadStream();
                request.ImageUrl = await imageStorage.UploadAsync(stream, fileName, request.File.ContentType);
            }
            else
            {
                request.ImageUrl = product.ImageUrl;
            }

            mapper.Map(request, product);
            repository.Update(product);

            return await unitOfWork.SaveChangesAsync()
                  ? Result.SuccessResult("Ürün güncellendi")
                : Result.Failure("Ürün güncellenemedi");
        }
    }
}
