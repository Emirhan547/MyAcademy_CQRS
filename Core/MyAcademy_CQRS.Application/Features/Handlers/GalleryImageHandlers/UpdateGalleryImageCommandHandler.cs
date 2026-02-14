using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Common.Storage;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.GalleryImageCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.GalleryImageHandlers
{
    public class UpdateGalleryImageCommandHandler(
   IRepository<GalleryImage> repository,
    IUnitOfWork unitOfWork,
    IImageStorageService imageStorage)
    : IRequestHandler<UpdateGalleryImageCommand, Result>
    {
        public async Task<Result> Handle(UpdateGalleryImageCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity is null)
                return Result.Failure("Resim bulunamadı");

            entity.Title = request.Title;


            if (request.File is not null && request.File.Length > 0)
            {
                var oldObjectName = ImageStoragePathHelper.GetObjectNameFromUrl(entity.ImageUrl);
                if (!string.IsNullOrWhiteSpace(oldObjectName))
                {
                    await imageStorage.DeleteAsync(oldObjectName);
                }

                var fileName = $"gallery/{Guid.NewGuid()}{Path.GetExtension(request.File.FileName)}";
                await using var stream = request.File.OpenReadStream();
                entity.ImageUrl = await imageStorage.UploadAsync(stream, fileName, request.File.ContentType);
            }

            repository.Update(entity);

            return await unitOfWork.SaveChangesAsync()
               ? Result.SuccessResult("Resim bilgileri güncellendi")
                : Result.Failure("Güncelleme başarısız");
        }
    }

}
