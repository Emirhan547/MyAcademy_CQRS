using AutoMapper;
using MediatR;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Queries.NewsQueries;
using MyAcademyCQRS.Core.Application.Features.Results.NewsResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.NewsHandlers
{
    public class GetAllNewsQueryHandler(IRepository<News> repository, IMapper mapper) : IRequestHandler<GetAllNewsQuery, IList<GetAllNewsQueryResult>>
    {
        public async Task<IList<GetAllNewsQueryResult>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            var news = await repository.GetAllAsync();
            return mapper.Map<IList<GetAllNewsQueryResult>>(news.OrderByDescending(x => x.PublishDate).ToList());
        }
    }
}