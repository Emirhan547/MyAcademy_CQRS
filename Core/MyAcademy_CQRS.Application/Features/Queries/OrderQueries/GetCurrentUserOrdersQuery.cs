using MediatR;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Queries.OrderQueries;

public class GetCurrentUserOrdersQuery : IRequest<IList<Order>>
{
}