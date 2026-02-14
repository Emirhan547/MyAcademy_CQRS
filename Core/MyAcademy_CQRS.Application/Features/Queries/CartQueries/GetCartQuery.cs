using MediatR;
using MyAcademy_CQRS.Application.Features.Results.CartResults;
using MyAcademyCQRS.Core.Application.Common.Results;


namespace MyAcademyCQRS.Core.Application.Features.Queries.CartQueries
{
    public class GetCartQuery : IRequest<DataResult<GetCartQueryResult>>
    {
    }
}