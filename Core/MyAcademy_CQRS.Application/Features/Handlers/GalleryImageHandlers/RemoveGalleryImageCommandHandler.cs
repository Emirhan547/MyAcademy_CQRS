using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.GalleryImageCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.GalleryImageHandlers
{
    public class RemoveGalleryImageCommandHandler(
    IRepository<GalleryImage> _repository,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<RemoveGalleryImageCommand, Result>
    {
        public async Task<Result> Handle(RemoveGalleryImageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity is null)
                return Result.Failure("Resim bulunamadı");

            entity.IsActive = false;
            _repository.Update(entity);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Resim pasife alındı")
                : Result.Failure("İşlem başarısız");
        }
    }

}
