using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Common.Storage;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.NewsCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.NewsHandlers
{
    public class CreateNewsCommandHandler(IRepository<News> repository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateNewsCommand> validator, IImageStorageService imageStorage) : IRequestHandler<CreateNewsCommand, Result>
    {
        public async Task<Result> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid) return Result.Failure(vr.Errors.First().ErrorMessage);
            var fileName = $"news/{Guid.NewGuid()}{Path.GetExtension(request.File.FileName)}";
            await using var stream = request.File.OpenReadStream();
            request.ImageUrl = await imageStorage.UploadAsync(stream, fileName, request.File.ContentType);
            await repository.CreateAsync(mapper.Map<News>(request));
            return await unitOfWork.SaveChangesAsync() ? Result.SuccessResult("Haber eklendi") : Result.Failure("Haber eklenemedi");
        }
    }
}