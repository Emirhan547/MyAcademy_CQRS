using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.ServiceCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler(IRepository<Service>_repository,IUnitOfWork _unitOfWork) : IRequestHandler<RemoveServiceCommand, Result>
    {
        public async Task<Result> Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync(request.Id);
            if (service is null)
                return Result.Failure("Service bulunamadı");

            service.IsActive = false;
            _repository.Update(service);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Service pasife alındı")
                : Result.Failure("İşlem başarısız");
        }
    }
}
