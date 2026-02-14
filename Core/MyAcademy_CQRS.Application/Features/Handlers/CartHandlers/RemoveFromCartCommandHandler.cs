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
    public class RemoveFromCartCommandHandler(IHttpContextAccessor httpContextAccessor)
         : IRequestHandler<RemoveFromCartCommand, Result>
    {
        public Task<Result> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
        {
            var store = new SessionCartStore(httpContextAccessor);
            var items = store.Get();
            var existing = items.FirstOrDefault(x => x.ProductId == request.ProductId);
            if (existing is null)
            {
                return Task.FromResult(Result.Failure("Sepette ürün bulunamadı."));
            }

            items.Remove(existing);
            store.Save(items);
            return Task.FromResult(Result.SuccessResult("Ürün sepetten kaldırıldı."));
        }
    }
}
