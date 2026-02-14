namespace MyAcademyCQRS.Core.Application.Contracts
{
    public interface IDomainEventPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : IDomainEvent;
    }
}
