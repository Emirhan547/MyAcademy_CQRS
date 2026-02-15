using MediatR;
using Microsoft.AspNetCore.Http;
using MyAcademy_CQRS.Application.Contracts.Sessions;
using MyAcademy_CQRS.Application.Features.Commands.CartCommands;
using MyAcademyCQRS.Core.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Handlers.CartHandlers;

public class UpdateCartItemQuantityCommandHandler(ICartSessionService cartSessionService)
    : IRequestHandler<UpdateCartItemQuantityCommand, Result>
{
    public Task<Result> Handle(UpdateCartItemQuantityCommand request, CancellationToken cancellationToken)
    {
        var items = cartSessionService.GetItems();
        var existing = items.FirstOrDefault(x => x.ProductId == request.ProductId);

        if (request.Quantity <= 0)
        {
            items.Remove(existing);
        }
        else
        {
            existing.Quantity = request.Quantity;
        }
        cartSessionService.SaveItems(items);
        return Task.FromResult(Result.SuccessResult("Sepet güncellendi."));
    }
}
