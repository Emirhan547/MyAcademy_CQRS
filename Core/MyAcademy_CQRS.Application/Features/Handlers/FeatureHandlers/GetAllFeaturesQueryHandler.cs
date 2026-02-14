using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.FeatureQueries;
using MyAcademyCQRS.Core.Application.Features.Results.FeatureResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.FeatureHandlers
{
    public class GetAllFeaturesQueryHandler(IRepository<Feature> _repository, IMapper _mapper) : IRequestHandler<GetAllFeaturesQuery, IList<GetAllFeaturesQueryResult>>
    {
        public async Task<IList<GetAllFeaturesQueryResult>> Handle(GetAllFeaturesQuery request, CancellationToken cancellationToken)
        {
            var features = await _repository.GetAllAsync();
            return _mapper.Map<IList<GetAllFeaturesQueryResult>>(features);
        }
    }
}
