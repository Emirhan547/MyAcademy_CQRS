using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.OurStoryResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.OurStoryQueries
{
    public class GetOurStoryByIdQuery
        : IRequest<GetActiveOurStoryQueryResult>
    {
        public int Id { get; set; }
    }
}
