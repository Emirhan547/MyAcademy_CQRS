using AutoMapper;
using MediatR;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Queries.SliderQueries;
using MyAcademyCQRS.Core.Application.Features.Results.SliderResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.SliderHandlers
{
    public class GetSliderByIdQueryHandler(
        IRepository<Slider> _repository,
        IMapper _mapper)
        : IRequestHandler<GetSliderByIdQuery, GetSliderByIdQueryResult>
    {
        public async Task<GetSliderByIdQueryResult> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            return entity is null
                ? null
                : _mapper.Map<GetSliderByIdQueryResult>(entity);
        }
    }
}