using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.SliderResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.SliderQueries
{
    public class GetActiveSlidersQuery
        : IRequest<IList<GetActiveSlidersQueryResult>>
    {
    }

}
