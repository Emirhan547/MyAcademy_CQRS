using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.NewsCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.NewsHandlers
{
    public class RemoveNewsCommandHandler(IRepository<News> repository, IUnitOfWork unitOfWork) : IRequestHandler<RemoveNewsCommand, Result>
    {
        public async Task<Result> Handle(RemoveNewsCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity is null) return Result.Failure("Haber bulunamadı");
            entity.IsActive = false;
            repository.Update(entity);
            return await unitOfWork.SaveChangesAsync() ? Result.SuccessResult("Haber pasife alındı") : Result.Failure("İşlem başarısız");
        }
    }
}