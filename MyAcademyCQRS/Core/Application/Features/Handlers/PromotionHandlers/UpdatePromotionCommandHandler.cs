using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.PromotionCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.PromotionHandlers
{
    public class UpdatePromotionCommandHandler(
    IRepository<Promotion> _repository,
    IUnitOfWork _unitOfWork,
    IMapper _mapper,
    IValidator<UpdatePromotionCommand> _validator)
    : IRequestHandler<UpdatePromotionCommand, Result>
    {
        public async Task<Result> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            var vr = await _validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity is null)
                return Result.Failure("Promotion bulunamadı");

            _mapper.Map(request, entity);
            _repository.Update(entity);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Promotion güncellendi")
                : Result.Failure("Güncelleme başarısız");
        }
    }

}
