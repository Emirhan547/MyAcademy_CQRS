using AutoMapper;
using MediatR;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Queries.SliderQueries;
using MyAcademyCQRS.Core.Application.Features.Results.SliderResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.SliderHandlers
{
    public class GetAllSlidersQueryHandler(IRepository<Slider>_repository,IMapper _mapper) : IRequestHandler<GetAllSlidersQuery, IList<GetAllSlidersQueryResult>>
    {
        public async Task<IList<GetAllSlidersQueryResult>> Handle(GetAllSlidersQuery request, CancellationToken cancellationToken)
        {
            var sliders = await _repository.GetAllAsync();
            return _mapper.Map<IList<GetAllSlidersQueryResult>>(sliders);
        }
    }
}
