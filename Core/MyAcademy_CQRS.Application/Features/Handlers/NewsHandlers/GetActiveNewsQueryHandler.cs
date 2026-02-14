using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.NewsQueries;
using MyAcademyCQRS.Core.Application.Features.Results.NewsResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.NewsHandlers
{
    public class GetActiveNewsQueryHandler(IRepository<News> repository, IMapper mapper) : IRequestHandler<GetActiveNewsQuery, IList<GetActiveNewsQueryResult>>
    {
        public async Task<IList<GetActiveNewsQueryResult>> Handle(GetActiveNewsQuery request, CancellationToken cancellationToken)
        {
            var news = await repository.GetAllAsync();
            return mapper.Map<IList<GetActiveNewsQueryResult>>(news.Where(x => x.IsActive).OrderByDescending(x => x.PublishDate).Take(3).ToList());
        }
    }
}