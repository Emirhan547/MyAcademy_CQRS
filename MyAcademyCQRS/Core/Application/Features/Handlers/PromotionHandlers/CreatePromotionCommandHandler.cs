using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.PromotionCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.PromotionHandlers
{
    public class CreatePromotionCommandHandler(
        IRepository<Promotion> _repository,
        IUnitOfWork _unitOfWork,
        IMapper _mapper,
        IValidator<CreatePromotionCommand> _validator)
        : IRequestHandler<CreatePromotionCommand, Result>
    {
        public async Task<Result> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var vr = await _validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            var entity = _mapper.Map<Promotion>(request);
            await _repository.CreateAsync(entity);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Promotion eklendi")
                : Result.Failure("İşlem başarısız");
        }
    }
}
