using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactInfoCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ContactInfoHandlers
{
    public class RemoveContactInfoCommandHandler(IRepository<ContactInfo> repository, IUnitOfWork unitOfWork) : IRequestHandler<RemoveContactInfoCommand, Result>
    {
        public async Task<Result> Handle(RemoveContactInfoCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity is null) return Result.Failure("İletişim bilgisi bulunamadı");
            entity.IsActive = false;
            repository.Update(entity);
            return await unitOfWork.SaveChangesAsync() ? Result.SuccessResult("İletişim bilgisi pasife alındı") : Result.Failure("İşlem başarısız");
        }
    }
}