using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.PromotionCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.PromotionHandlers
{
    public class RemovePromotionCommandHandler(
     IRepository<Promotion> _repository,
     IUnitOfWork _unitOfWork)
     : IRequestHandler<RemovePromotionCommand, Result>
    {
        public async Task<Result> Handle(RemovePromotionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity is null)
                return Result.Failure("Promotion bulunamadı");

            entity.IsActive = false;
            _repository.Update(entity);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Promotion pasife alındı")
                : Result.Failure("İşlem başarısız");
        }
    }

}
