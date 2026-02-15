using MediatR;
using MyAcademy_CQRS.Application.Contracts.Sessions;

using MyAcademy_CQRS.Application.Features.Commands.CartCommands;
using MyAcademyCQRS.Core.Application.Common.Results;


namespace MyAcademy_CQRS.Application.Features.Handlers.CartHandlers;

public class RemoveFromCartCommandHandler(ICartSessionService cartSessionService)
     : IRequestHandler<RemoveFromCartCommand, Result>
{
    public Task<Result> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
    {
        var items = cartSessionService.GetItems();
        var existing = items.FirstOrDefault(x => x.ProductId == request.ProductId);
        if (existing is null)
        { 
            return Task.FromResult(Result.Failure("Sepette ürün bulunamadı."));
    }
    items.Remove(existing);
        cartSessionService.SaveItems(items);
        return Task.FromResult(Result.SuccessResult("Ürün sepetten kaldırıldı."));
    }
}
