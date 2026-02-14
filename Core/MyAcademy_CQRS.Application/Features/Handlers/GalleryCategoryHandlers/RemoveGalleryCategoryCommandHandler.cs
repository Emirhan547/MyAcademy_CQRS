using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.GalleryCategoryCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.GalleryCategoryHandlers
{
    public class RemoveGalleryCategoryCommandHandler(
    IRepository<GalleryCategory> _repository,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<RemoveGalleryCategoryCommand, Result>
    {
        public async Task<Result> Handle(RemoveGalleryCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity is null)
                return Result.Failure("Kategori bulunamadı");

            entity.IsActive = false;
            _repository.Update(entity);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Kategori pasife alındı")
                : Result.Failure("İşlem başarısız");
        }
    }

}
