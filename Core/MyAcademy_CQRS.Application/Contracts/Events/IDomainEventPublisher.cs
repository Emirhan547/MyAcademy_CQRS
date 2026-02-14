namespace MyAcademy_CQRS.Application.Contracts.Events
{
    public interface IDomainEventPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : IDomainEvent;
    }
}
