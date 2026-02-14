using MediatR;

namespace MyAcademyCQRS.Core.Application.Features.Queries.CartQueries
{
    public class GetCartItemCountQuery : IRequest<int>
    {
    }
}