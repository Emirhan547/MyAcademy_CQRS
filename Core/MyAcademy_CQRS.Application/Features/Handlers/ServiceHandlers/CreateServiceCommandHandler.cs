using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.ServiceCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler(IRepository<Service>_repository,IUnitOfWork _unitOfWork,IMapper _mapper,IValidator<CreateServiceCommand>_validator) : IRequestHandler<CreateServiceCommand, Result>
    {
        public async Task<Result> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var vr = await _validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            var service = _mapper.Map<Service>(request);
            await _repository.CreateAsync(service);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Service eklendi")
                : Result.Failure("Service eklenemedi");

        }
    }
}
