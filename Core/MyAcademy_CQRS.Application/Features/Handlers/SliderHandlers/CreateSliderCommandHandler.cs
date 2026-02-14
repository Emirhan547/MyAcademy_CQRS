using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Common.Storage;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.SliderCommands;
using MyAcademyCQRS.Core.Application.Validators;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.SliderHandlers
{
    public class CreateSliderCommandHandler(IRepository<Slider> repository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateSliderCommand> validator, IImageStorageService imageStorage) : IRequestHandler<CreateSliderCommand, Result>
    {
        public async Task<Result> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {

            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors.First().ErrorMessage);
            }

            var bgFileName = $"sliders/background/{Guid.NewGuid()}{Path.GetExtension(request.BackgroundImageFile.FileName)}";
            await using var bgStream = request.BackgroundImageFile.OpenReadStream();
            request.BackgroundImageUrl = await imageStorage.UploadAsync(bgStream, bgFileName, request.BackgroundImageFile.ContentType);

            var productFileName = $"sliders/product/{Guid.NewGuid()}{Path.GetExtension(request.ProductImageFile.FileName)}";
            await using var productStream = request.ProductImageFile.OpenReadStream();
            request.ProductImageUrl = await imageStorage.UploadAsync(productStream, productFileName, request.ProductImageFile.ContentType);

            var slider = mapper.Map<Slider>(request);
            await repository.CreateAsync(slider);
            var saved = await unitOfWork.SaveChangesAsync();

            return saved
                ? Result.SuccessResult("Slider başarıyla eklendi")
                : Result.Failure("Slider eklenirken hata oluştu");
        }
    }
}
