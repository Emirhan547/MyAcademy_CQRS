using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactMessages;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ContactMessageHandlers
{
    public class RemoveContactMessageCommandHandler(
     IRepository<ContactMessage> _repository,
     IUnitOfWork _unitOfWork)
     : IRequestHandler<RemoveContactMessageCommand, Result>
    {
        public async Task<Result> Handle(RemoveContactMessageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity is null)
                return Result.Failure("Mesaj bulunamadı");

            entity.IsActive = false;

            _repository.Update(entity);

            var saved = await _unitOfWork.SaveChangesAsync();

            return saved
                ? Result.SuccessResult("Mesaj silindi")
                : Result.Failure("İşlem başarısız");
        }
    }

}
