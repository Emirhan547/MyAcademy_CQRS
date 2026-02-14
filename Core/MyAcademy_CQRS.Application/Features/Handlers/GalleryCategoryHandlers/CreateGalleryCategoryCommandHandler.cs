using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.GalleryCategoryCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.GalleryCategoryHandlers
{
    public class CreateGalleryCategoryCommandHandler(
    IRepository<GalleryCategory> _repository,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<CreateGalleryCategoryCommand, Result>
    {
        public async Task<Result> Handle(CreateGalleryCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new GalleryCategory
            {
                Name = request.Name
            };

            await _repository.CreateAsync(entity);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Kategori eklendi")
                : Result.Failure("İşlem başarısız");
        }
    }
}
