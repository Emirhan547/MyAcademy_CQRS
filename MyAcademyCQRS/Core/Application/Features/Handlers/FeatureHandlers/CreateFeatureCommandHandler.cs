using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.FeatureCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler(IRepository<Feature> _repository, IUnitOfWork _unitOfWork, IMapper _mapper, IValidator<CreateFeatureCommand> _validator) : IRequestHandler<CreateFeatureCommand, Result>
    {
        public async Task<Result> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Failure(validationResult.Errors.First().ErrorMessage);
            var feature=_mapper.Map<Feature>(request);
            await _repository.CreateAsync(feature);
            var saved= await _unitOfWork.SaveChangesAsync();
            return saved ? Result.SuccessResult("Feature başarıyla eklendi") : Result.Failure("Feature eklenmedi");
                
        }
    }
}
