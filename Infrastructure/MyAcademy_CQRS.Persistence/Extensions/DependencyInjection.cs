
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAcademy_CQRS.Application.Common.Storage;
using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.Services;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademy_CQRS.Infrastructure.Identities;
using MyAcademy_CQRS.Persistence.Concrete;
using MyAcademy_CQRS.Persistence.Context;
using MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers.CreationChain;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Core.Domain.Events.ContactMessageEvents;
using MyAcademyCQRS.Core.Domain.Events.OrderEvents;
using MyAcademyCQRS.Core.Domain.Events.PromotionEvents;


namespace MyAcademy_CQRS.Persistence.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IGalleryCategoryReadRepository, GalleryCategoryReadRepository>();
            services.AddScoped<IActivityLogService, ActivityLogService>();

            return services;
        }

    }
}