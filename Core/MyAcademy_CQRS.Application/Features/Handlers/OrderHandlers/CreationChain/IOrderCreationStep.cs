namespace MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers.CreationChain
{
    public interface IOrderCreationStep
    {
        IOrderCreationStep SetNext(IOrderCreationStep next);
        Task<bool> ExecuteAsync(OrderCreationContext context, CancellationToken cancellationToken);
    }
}