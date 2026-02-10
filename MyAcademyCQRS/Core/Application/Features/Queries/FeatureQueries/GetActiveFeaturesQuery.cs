using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.FeatureResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.FeatureQueries
{
    public class GetActiveFeaturesQuery : IRequest<IList<GetActiveFeaturesQueryResult>>
    {
    }
}
