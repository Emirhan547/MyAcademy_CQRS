using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.FeatureQueries;
using MyAcademyCQRS.Core.Application.Features.Results.FeatureResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler(
        IRepository<Feature> _repository,
        IMapper _mapper)
        : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            return entity is null
                ? null
                : _mapper.Map<GetFeatureByIdQueryResult>(entity);
        }
    }
}