using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.GalleryCategoryCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.GalleryCategoryHandlers
{
    public class UpdateGalleryCategoryCommandHandler(
     IRepository<GalleryCategory> _repository,
     IUnitOfWork _unitOfWork)
     : IRequestHandler<UpdateGalleryCategoryCommand, Result>
    {
        public async Task<Result> Handle(UpdateGalleryCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity is null)
                return Result.Failure("Kategori bulunamadı");

            entity.Name = request.Name;
            entity.IsActive = request.IsActive;

            _repository.Update(entity);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Güncellendi")
                : Result.Failure("Güncelleme başarısız");
        }
    }

}
