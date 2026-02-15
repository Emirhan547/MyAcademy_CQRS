using Microsoft.Extensions.DependencyInjection;
using MyAcademy_CQRS.Application.Common.Storage;
using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademy_CQRS.Application.Contracts.Identities;
using MyAcademy_CQRS.Application.Contracts.Sessions;
using MyAcademy_CQRS.Infrastructure.Eventing;
using MyAcademy_CQRS.Infrastructure.Services;
using MyAcademy_CQRS.Infrastructure.Storage;
using MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers.CreationChain;
using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Core.Domain.Events.ContactMessageEvents;
using MyAcademyCQRS.Core.Domain.Events.OrderEvents;
using MyAcademyCQRS.Core.Domain.Events.PromotionEvents;


namespace MyAcademy_CQRS.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IImageStorageService, GoogleCloudStorageService>();
        services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();
        services.AddScoped<ICartSessionService, SessionCartService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddScoped<IDomainEventHandler<OrderCreatedEvent>, OrderLogEventHandler>();
        services.AddScoped<IDomainEventHandler<OrderStatusChangedEvent>, OrderLogEventHandler>();
        services.AddScoped<IDomainEventHandler<OrderCreatedEvent>, OrderMailEventHandler>();
        services.AddScoped<IDomainEventHandler<OrderStatusChangedEvent>, OrderMailEventHandler>();
        services.AddScoped<IDomainEventHandler<PromotionCreatedEvent>, PromotionEventLogHandler>();
        services.AddScoped<IDomainEventHandler<PromotionUpdatedEvent>, PromotionEventLogHandler>();
        services.AddScoped<IDomainEventHandler<ContactMessageReceivedEvent>, ContactMessageEventLogHandler>();
        services.AddScoped<IDomainEventHandler<ContactMessageUpdatedEvent>, ContactMessageEventLogHandler>();

        services.AddScoped<StockControlStep>();
        services.AddScoped<PriceValidationStep>();
        services.AddScoped<PromotionApplyStep>();
        services.AddScoped<FraudRuleControlStep>();
        services.AddScoped<FinalPersistStep>();

        return services;
    }
}