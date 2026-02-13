using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.NewsResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.NewsQueries
{
    public class GetActiveNewsQuery : IRequest<IList<GetActiveNewsQueryResult>>
    {
    }
}