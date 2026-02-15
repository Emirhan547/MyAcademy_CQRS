
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAcademy_CQRS.Application.Common.Storage;
using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademy_CQRS.Application.Contracts.Identities;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.Services;
using MyAcademy_CQRS.Application.Contracts.Sessions;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademy_CQRS.Infrastructure.Services;
using MyAcademy_CQRS.Persistence.Persistence.Concrete;
using MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers.CreationChain;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Core.Domain.Events.ContactMessageEvents;
using MyAcademyCQRS.Core.Domain.Events.OrderEvents;
using MyAcademyCQRS.Core.Domain.Events.PromotionEvents;
using MyAcademyCQRS.Infrastructure.Observeres;
using MyAcademyCQRS.Infrastructure.Persistence.Concrete;
using MyAcademyCQRS.Infrastructure.Persistence.Context;
using MyAcademyCQRS.Infrastructure.Services;
using MyAcademyCQRS.Infrastructure.Storage;

namespace MyAcademy_CQRS.Persistence.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
           
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IGalleryCategoryReadRepository, GalleryCategoryReadRepository>();
            services.AddScoped<IImageStorageService, GoogleCloudStorageService>();
            services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();
            services.AddScoped<IActivityLogService, ActivityLogService>();
            services.AddScoped<IDomainEventHandler<OrderCreatedEvent>, OrderLogEventHandler>();
            services.AddScoped<IDomainEventHandler<OrderStatusChangedEvent>, OrderLogEventHandler>();
            services.AddScoped<IDomainEventHandler<OrderCreatedEvent>, OrderMailEventHandler>();
            services.AddScoped<IDomainEventHandler<OrderStatusChangedEvent>, OrderMailEventHandler>();
            services.AddScoped<ICartSessionService, SessionCartService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
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
}