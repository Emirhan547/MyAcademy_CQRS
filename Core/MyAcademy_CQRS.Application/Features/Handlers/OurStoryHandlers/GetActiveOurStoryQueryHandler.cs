using AutoMapper;
using MediatR;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Queries.OurStoryQueries;
using MyAcademyCQRS.Core.Application.Features.Results.OurStoryResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.OurStoryHandlers
{
    public class GetActiveOurStoryQueryHandler(
       IRepository<OurStory> _repository,
       IMapper _mapper)
       : IRequestHandler<GetActiveOurStoryQuery, GetActiveOurStoryQueryResult>
    {
        public async Task<GetActiveOurStoryQueryResult> Handle(
            GetActiveOurStoryQuery request,
            CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            var active = data.FirstOrDefault(x => x.IsActive);

            return active is null
                ? null
                : _mapper.Map<GetActiveOurStoryQueryResult>(active);
        }
    }
}
