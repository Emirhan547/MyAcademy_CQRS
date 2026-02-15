using MediatR;
using MyAcademy_CQRS.Application.Contracts.Sessions;
using MyAcademy_CQRS.Application.Features.Commands.CartCommands;
using MyAcademyCQRS.Core.Application.Common.Results;


namespace MyAcademy_CQRS.Application.Features.Handlers.CartHandlers;
public class ClearCartCommandHandler(ICartSessionService cartSessionService)
    : IRequestHandler<ClearCartCommand, Result>
{
       public Task<Result> Handle(ClearCartCommand request, CancellationToken cancellationToken)
{
        cartSessionService.Clear();
        return Task.FromResult(Result.SuccessResult("Sepet temizlendi."));
    }
    }

