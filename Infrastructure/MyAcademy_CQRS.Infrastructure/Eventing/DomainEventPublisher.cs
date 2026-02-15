using Microsoft.Extensions.DependencyInjection;
using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademyCQRS.Core.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Infrastructure.Eventing
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
