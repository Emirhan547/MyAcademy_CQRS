using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.OurStoryResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.OurStoryQueries
{
    public class GetActiveOurStoryQuery
         : IRequest<GetActiveOurStoryQueryResult>
    {
    }
}
