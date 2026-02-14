using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Common.Storage;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactInfoCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ContactInfoHandlers
{
    public class CreateContactInfoCommandHandler(IRepository<ContactInfo> repository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateContactInfoCommand> validator, IImageStorageService imageStorage) : IRequestHandler<CreateContactInfoCommand, Result>
    {
        public async Task<Result> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid) return Result.Failure(vr.Errors.First().ErrorMessage);
            var fileName = $"contactinfo/{Guid.NewGuid()}{Path.GetExtension(request.File.FileName)}";
            await using var stream = request.File.OpenReadStream();
            request.BackgroundImageUrl = await imageStorage.UploadAsync(stream, fileName, request.File.ContentType);
            await repository.CreateAsync(mapper.Map<ContactInfo>(request));
            return await unitOfWork.SaveChangesAsync() ? Result.SuccessResult("İletişim bilgisi eklendi") : Result.Failure("İletişim bilgisi eklenemedi");
        }
    }
}