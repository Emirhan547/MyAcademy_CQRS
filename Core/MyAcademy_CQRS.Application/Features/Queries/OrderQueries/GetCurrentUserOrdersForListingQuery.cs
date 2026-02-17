using MediatR;
using MyAcademyCQRS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Queries.OrderQueries
{
    public class GetCurrentUserOrdersForListingQuery : IRequest<IList<Order>>
    {
    }
}
