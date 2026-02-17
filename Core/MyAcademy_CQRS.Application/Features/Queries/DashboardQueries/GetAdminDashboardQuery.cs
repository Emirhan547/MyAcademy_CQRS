using MediatR;
using MyAcademy_CQRS.Application.Features.Results.DashboardResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Queries.DashboardQueries
{
    public class GetAdminDashboardQuery : IRequest<GetAdminDashboardQueryResult>
    {
    }
}
