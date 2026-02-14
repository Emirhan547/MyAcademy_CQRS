using MyAcademy_CQRS.Application.Contracts.Events;

namespace MyAcademyCQRS.Infrastructure.Observeres
{
    public class DomainEventPublisher(IServiceProvider serviceProvider) : IDomainEventPublisher
    {
        public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : IDomainEvent
        {
            var handlers = serviceProvider.GetServices<IDomainEventHandler<TEvent>>();
            foreach (var handler in handlers)
            {
                await handler.HandleAsync(@event, cancellationToken);
            }
        }
    }
}