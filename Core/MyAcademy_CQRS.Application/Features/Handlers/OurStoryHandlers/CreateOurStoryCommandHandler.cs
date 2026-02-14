using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Common.Storage;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.OurStoryCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.OurStoryHandlers
{
    public class CreateOurStoryCommandHandler(
        IRepository<OurStory> repository,
         IUnitOfWork unitOfWork,
         IMapper mapper,
         IValidator<CreateOurStoryCommand> validator,
         IImageStorageService imageStorage)
         : IRequestHandler<CreateOurStoryCommand, Result>
    {
        public async Task<Result> Handle(CreateOurStoryCommand request, CancellationToken cancellationToken)
        {
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            var fileName = $"ourstory/{Guid.NewGuid()}{Path.GetExtension(request.File.FileName)}";
            await using var stream = request.File.OpenReadStream();
            request.ImageUrl = await imageStorage.UploadAsync(stream, fileName, request.File.ContentType);

            var entity = mapper.Map<OurStory>(request);
            await repository.CreateAsync(entity);

            return await unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("OurStory eklendi")
                : Result.Failure("İşlem başarısız");
        }
    }
}
