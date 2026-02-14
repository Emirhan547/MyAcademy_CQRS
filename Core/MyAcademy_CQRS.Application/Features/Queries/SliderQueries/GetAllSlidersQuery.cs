using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.SliderResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.SliderQueries
{
    public class GetAllSlidersQuery
        : IRequest<IList<GetAllSlidersQueryResult>>
    {
    }
}
