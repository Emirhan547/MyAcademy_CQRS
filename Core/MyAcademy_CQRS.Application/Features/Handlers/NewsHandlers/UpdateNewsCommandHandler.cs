using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Common.Storage;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Common.Storage;
using MyAcademyCQRS.Core.Application.Features.Commands.NewsCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.NewsHandlers
{
    public class UpdateNewsCommandHandler(IRepository<News> repository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateNewsCommand> validator, IImageStorageService imageStorage) : IRequestHandler<UpdateNewsCommand, Result>
    {
        public async Task<Result> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid) return Result.Failure(vr.Errors.First().ErrorMessage);
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity is null) return Result.Failure("Haber bulunamadı");
            if (request.File is not null && request.File.Length > 0)
            {
                var oldObjectName = ImageStoragePathHelper.GetObjectNameFromUrl(entity.ImageUrl);
                if (!string.IsNullOrWhiteSpace(oldObjectName))
                {
                    await imageStorage.DeleteAsync(oldObjectName);
                }

                var fileName = $"news/{Guid.NewGuid()}{Path.GetExtension(request.File.FileName)}";
                await using var stream = request.File.OpenReadStream();
                request.ImageUrl = await imageStorage.UploadAsync(stream, fileName, request.File.ContentType);
            }
            else
            {
                request.ImageUrl = entity.ImageUrl;
            }
            mapper.Map(request, entity);
            repository.Update(entity);
            return await unitOfWork.SaveChangesAsync() ? Result.SuccessResult("Haber güncellendi") : Result.Failure("Haber güncellenemedi");
        }
    }
}