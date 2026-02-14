using AutoMapper;
using MediatR;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Queries.FeatureQueries;
using MyAcademyCQRS.Core.Application.Features.Results.FeatureResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.FeatureHandlers
{
    public class GetActiveFeaturesQueryHandler(IRepository<Feature> _repository, IMapper _mapper) : IRequestHandler<GetActiveFeaturesQuery, IList<GetActiveFeaturesQueryResult>>
    {
        public async Task<IList<GetActiveFeaturesQueryResult>> Handle(GetActiveFeaturesQuery request, CancellationToken cancellationToken)
        {
            var features = await _repository.GetAllAsync();

            var activeFeatures = features
                .Where(x => x.IsActive)
                .OrderBy(x => x.StepNumber)
                .ToList();

            return _mapper.Map<IList<GetActiveFeaturesQueryResult>>(activeFeatures);
        }
    }
}
