using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Common.Storage;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Common.Storage;
using MyAcademyCQRS.Core.Application.Features.Commands.SliderCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.SliderHandlers
{
    public class UpdateSliderCommandHandler(IRepository<Slider> repository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateSliderCommand> validator, IImageStorageService imageStorage) : IRequestHandler<UpdateSliderCommand, Result>
    {
        public async Task<Result> Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors.First().ErrorMessage);
            }
            var slider = await repository.GetByIdAsync(request.Id);
            if (slider == null)
                return Result.Failure("Slider bulunamadı");

            if (request.BackgroundImageFile is not null && request.BackgroundImageFile.Length > 0)
            {
                var oldBackgroundObjectName = ImageStoragePathHelper.GetObjectNameFromUrl(slider.BackgroundImageUrl);
                if (!string.IsNullOrWhiteSpace(oldBackgroundObjectName))
                {
                    await imageStorage.DeleteAsync(oldBackgroundObjectName);
                }

                var bgFileName = $"sliders/background/{Guid.NewGuid()}{Path.GetExtension(request.BackgroundImageFile.FileName)}";
                await using var bgStream = request.BackgroundImageFile.OpenReadStream();
                request.BackgroundImageUrl = await imageStorage.UploadAsync(bgStream, bgFileName, request.BackgroundImageFile.ContentType);
            }
            else
            {
                request.BackgroundImageUrl = slider.BackgroundImageUrl;
            }

            if (request.ProductImageFile is not null && request.ProductImageFile.Length > 0)
            {
                var oldProductObjectName = ImageStoragePathHelper.GetObjectNameFromUrl(slider.ProductImageUrl);
                if (!string.IsNullOrWhiteSpace(oldProductObjectName))
                {
                    await imageStorage.DeleteAsync(oldProductObjectName);
                }

                var productFileName = $"sliders/product/{Guid.NewGuid()}{Path.GetExtension(request.ProductImageFile.FileName)}";
                await using var productStream = request.ProductImageFile.OpenReadStream();
                request.ProductImageUrl = await imageStorage.UploadAsync(productStream, productFileName, request.ProductImageFile.ContentType);
            }
            else
            {
                request.ProductImageUrl = slider.ProductImageUrl;
            }

            mapper.Map(request, slider);

            repository.Update(slider);
            var saved = await unitOfWork.SaveChangesAsync();

            return saved
                ? Result.SuccessResult("Slider başarıyla güncellendi")
                : Result.Failure("Slider güncellenemedi");
        }
    }
    }

