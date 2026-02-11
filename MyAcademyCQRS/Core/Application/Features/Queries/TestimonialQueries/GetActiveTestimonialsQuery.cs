using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.TestimonialResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.TestimonialQueries
{
    public class GetActiveTestimonialsQuery
        : IRequest<IList<GetActiveTestimonialsQueryResult>>
    {
    }
}
