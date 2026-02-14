using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.ServiceCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler(IRepository<Service> _repository, IUnitOfWork _unitOfWork, IMapper _mapper, IValidator<UpdateServiceCommand> _validator) : IRequestHandler<UpdateServiceCommand, Result>
    {
        public async Task<Result> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var vr = await _validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            var service = await _repository.GetByIdAsync(request.Id);
            if (service is null)
                return Result.Failure("Service bulunamadı");

            _mapper.Map(request, service);
            _repository.Update(service);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Service güncellendi")
                : Result.Failure("Service güncellenemedi");
        }
    }
}
