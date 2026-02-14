using MediatR;
using Microsoft.AspNetCore.Http;
using MyAcademyCQRS.Core.Application.Features.Queries.CartQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Handlers.CartHandlers
{
    public class GetCartItemCountQueryHandler(IHttpContextAccessor httpContextAccessor)
        : IRequestHandler<GetCartItemCountQuery, int>
    {
        public Task<int> Handle(GetCartItemCountQuery request, CancellationToken cancellationToken)
        {
            var count = new SessionCartStore(httpContextAccessor).Get().Sum(x => x.Quantity);
            return Task.FromResult(count);
        }
    }
}
