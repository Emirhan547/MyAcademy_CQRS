using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Common.Storage;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.OurStoryCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.OurStoryHandlers
{
    public class UpdateOurStoryCommandHandler(
  IRepository<OurStory> repository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IValidator<UpdateOurStoryCommand> validator,
    IImageStorageService imageStorage)
    : IRequestHandler<UpdateOurStoryCommand, Result>
    {
        public async Task<Result> Handle(UpdateOurStoryCommand request, CancellationToken cancellationToken)
        {
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            var entity = await repository.GetByIdAsync(request.Id);
            if (entity is null)
                return Result.Failure("Kayıt bulunamadı");

            if (request.File is not null && request.File.Length > 0)
            {
                var oldObjectName = ImageStoragePathHelper.GetObjectNameFromUrl(entity.ImageUrl);
                if (!string.IsNullOrWhiteSpace(oldObjectName))
                {
                    await imageStorage.DeleteAsync(oldObjectName);
                }

                var fileName = $"ourstory/{Guid.NewGuid()}{Path.GetExtension(request.File.FileName)}";
                await using var stream = request.File.OpenReadStream();
                request.ImageUrl = await imageStorage.UploadAsync(stream, fileName, request.File.ContentType);
            }
            else
            {
                request.ImageUrl = entity.ImageUrl;
            }

            mapper.Map(request, entity);
            repository.Update(entity);

            return await unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Güncellendi")
                : Result.Failure("Güncelleme başarısız");
        }
    }
}
