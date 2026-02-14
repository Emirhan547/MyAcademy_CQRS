using AutoMapper;
using MediatR;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Queries.NewsQueries;
using MyAcademyCQRS.Core.Application.Features.Results.NewsResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.NewsHandlers
{
    public class GetNewsByIdQueryHandler(IRepository<News> repository, IMapper mapper) : IRequestHandler<GetNewsByIdQuery, GetNewsByIdQueryResult>
    {
        public async Task<GetNewsByIdQueryResult> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            return entity is null ? null : mapper.Map<GetNewsByIdQueryResult>(entity);
        }
    }
}