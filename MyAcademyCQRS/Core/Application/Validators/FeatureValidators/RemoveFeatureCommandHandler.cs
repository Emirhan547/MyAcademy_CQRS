using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.FeatureCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Validators.FeatureValidators
{
    public class RemoveFeatureCommandHandler(IRepository<Feature> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveFeatureCommand, Result>
    {
        public async Task<Result> Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature=await _repository.GetByIdAsync(request.Id);
            if (feature is null)
                return Result.Failure("Feature bulunamadı");
            feature.IsActive = false;
            _repository.Update(feature);
            var saved=await _unitOfWork.SaveChangesAsync();
            return saved ? Result.SuccessResult("Feature pasife alındı") : Result.Failure("İşlem başarısız");
        }
    }
}
