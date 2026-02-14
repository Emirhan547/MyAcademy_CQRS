using MediatR;
using Microsoft.AspNetCore.Http;
using MyAcademy_CQRS.Application.Features.Commands.CartCommands;
using MyAcademyCQRS.Core.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Handlers.CartHandlers
{
    public class ClearCartCommandHandler(IHttpContextAccessor httpContextAccessor)
        : IRequestHandler<ClearCartCommand, Result>
    {
        public Task<Result> Handle(ClearCartCommand request, CancellationToken cancellationToken)
        {
            new SessionCartStore(httpContextAccessor).Clear();
            return Task.FromResult(Result.SuccessResult("Sepet temizlendi."));
        }
    }
}
