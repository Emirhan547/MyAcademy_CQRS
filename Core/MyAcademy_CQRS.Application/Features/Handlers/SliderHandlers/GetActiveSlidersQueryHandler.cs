using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.SliderQueries;
using MyAcademyCQRS.Core.Application.Features.Results.SliderResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.SliderHandlers
{
    public class GetActiveSlidersQueryHandler(IRepository<Slider> _repository, IMapper _mapper) : IRequestHandler<GetActiveSlidersQuery, IList<GetActiveSlidersQueryResult>>
    {
        public async Task<IList<GetActiveSlidersQueryResult>> Handle(GetActiveSlidersQuery request, CancellationToken cancellationToken)
        {
            var sliders = await _repository.GetAllAsync();
            var activeSliders=sliders
                .Where(x => x.IsActive)
                .OrderBy(x=>x.DisplayOrder)
                .ToList();
            return _mapper.Map<IList<GetActiveSlidersQueryResult>>(activeSliders);
        }
    }
}
