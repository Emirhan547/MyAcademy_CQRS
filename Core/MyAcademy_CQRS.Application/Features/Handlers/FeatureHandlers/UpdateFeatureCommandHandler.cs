using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.FeatureCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler(IRepository<Feature> _repository, IUnitOfWork _unitOfWork, IMapper _mapper, IValidator<UpdateFeatureCommand> _validator) : IRequestHandler<UpdateFeatureCommand, Result>
    {
        public async Task<Result> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Failure(validationResult.Errors.First().ErrorMessage);

            var feature = await _repository.GetByIdAsync(request.Id);
            if (feature is null)
                return Result.Failure("Feature bulunamadı");

            _mapper.Map(request, feature);
            _repository.Update(feature);

            var saved = await _unitOfWork.SaveChangesAsync();

            return saved
                ? Result.SuccessResult("Feature güncellendi")
                : Result.Failure("Feature güncellenemedi");
        }
    }
}
