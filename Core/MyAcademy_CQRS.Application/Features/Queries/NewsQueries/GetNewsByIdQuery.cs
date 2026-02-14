using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.NewsResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.NewsQueries
{
    public class GetNewsByIdQuery : IRequest<GetNewsByIdQueryResult>
    {
        public int Id { get; set; }
    }
}