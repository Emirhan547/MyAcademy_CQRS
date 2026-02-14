using MediatR;
using MyAcademy_CQRS.Application.Common.Storage;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.GalleryImageCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.GalleryImageHandlers
{
    public class CreateGalleryImageCommandHandler(IImageStorageService _imageStorage, IRepository<GalleryImage>_imageRepository,IRepository<GalleryCategory>_categoryRepository,IUnitOfWork _unitOfWork) : IRequestHandler<CreateGalleryImageCommand, Result>
    {
        public async Task<Result> Handle(CreateGalleryImageCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.GalleryCategoryId);
            if (category is null)
                return Result.Failure("Kategori bulunamadı");

            if (request.File is null || request.File.Length == 0)
                return Result.Failure("Dosya bulunamadı");

            var uniqueFileName =
                $"{Guid.NewGuid()}{Path.GetExtension(request.File.FileName)}";

            using var stream = request.File.OpenReadStream();

            var imageUrl = await _imageStorage.UploadAsync(
                stream,
                uniqueFileName,
                request.File.ContentType);

            var entity = new GalleryImage
            {
                Title = request.Title,
                ImageUrl = imageUrl,
                GalleryCategoryId = request.GalleryCategoryId
            };

            await _imageRepository.CreateAsync(entity);

            var saved = await _unitOfWork.SaveChangesAsync();

            return saved
                ? Result.SuccessResult("Resim başarıyla yüklendi")
                : Result.Failure("Kayıt başarısız");
        }
    }
}
