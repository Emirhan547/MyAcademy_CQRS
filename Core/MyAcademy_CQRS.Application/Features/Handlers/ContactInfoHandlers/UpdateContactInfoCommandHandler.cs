using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Common.Storage;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactInfoCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ContactInfoHandlers
{
    public class UpdateContactInfoCommandHandler(IRepository<ContactInfo> repository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateContactInfoCommand> validator, IImageStorageService imageStorage) : IRequestHandler<UpdateContactInfoCommand, Result>
    {
        public async Task<Result> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid) return Result.Failure(vr.Errors.First().ErrorMessage);
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity is null) return Result.Failure("İletişim bilgisi bulunamadı");
            if (request.File is not null && request.File.Length > 0)
            {
                var oldObjectName = ImageStoragePathHelper.GetObjectNameFromUrl(entity.BackgroundImageUrl);
                if (!string.IsNullOrWhiteSpace(oldObjectName))
                {
                    await imageStorage.DeleteAsync(oldObjectName);
                }

                var fileName = $"contactinfo/{Guid.NewGuid()}{Path.GetExtension(request.File.FileName)}";
                await using var stream = request.File.OpenReadStream();
                request.BackgroundImageUrl = await imageStorage.UploadAsync(stream, fileName, request.File.ContentType);
            }
            else
            {
                request.BackgroundImageUrl = entity.BackgroundImageUrl;
            }
            mapper.Map(request, entity);
            repository.Update(entity);
            return await unitOfWork.SaveChangesAsync() ? Result.SuccessResult("İletişim bilgisi güncellendi") : Result.Failure("İletişim bilgisi güncellenemedi");
        }
    }
}