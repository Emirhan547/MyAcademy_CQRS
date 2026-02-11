using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.GallerImageCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.GalleryImageHandlers
{
    public class UpdateGalleryImageCommandHandler(
    IRepository<GalleryImage> _repository,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<UpdateGalleryImageCommand, Result>
    {
        public async Task<Result> Handle(UpdateGalleryImageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity is null)
                return Result.Failure("Resim bulunamadı");

            entity.Title = request.Title;
            entity.ImageUrl = request.ImageUrl;

            _repository.Update(entity);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Resim güncellendi")
                : Result.Failure("Güncelleme başarısız");
        }
    }

}
