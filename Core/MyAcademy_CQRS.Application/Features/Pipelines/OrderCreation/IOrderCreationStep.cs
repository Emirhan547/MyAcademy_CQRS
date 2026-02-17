namespace MyAcademy_CQRS.Application.Features.Pipelines.OrderCreation
{
    public interface IOrderCreationStep
    {
        IOrderCreationStep SetNext(IOrderCreationStep next);
        Task<bool> ExecuteAsync(OrderCreationContext context, CancellationToken cancellationToken);
    }
}