using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.ServiceResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.ServiceQueries
{
    public class GetAllServicesQuery:IRequest<IList<GetAllServicesQueryResult>>
    {
    }
}
