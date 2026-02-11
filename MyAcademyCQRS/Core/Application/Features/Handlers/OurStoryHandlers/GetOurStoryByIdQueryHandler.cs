using AutoMapper;
using MediatR;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Queries.OurStoryQueries;
using MyAcademyCQRS.Core.Application.Features.Results.OurStoryResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.OurStoryHandlers
{
    public class GetOurStoryByIdQueryHandler(
        IRepository<OurStory> _repository,
        IMapper _mapper)
        : IRequestHandler<GetOurStoryByIdQuery, GetOurStoryByIdQueryResult>
    {
        public async Task<GetOurStoryByIdQueryResult> Handle(GetOurStoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            return entity is null
                ? null
                : _mapper.Map<GetOurStoryByIdQueryResult>(entity);
        }
    }
}