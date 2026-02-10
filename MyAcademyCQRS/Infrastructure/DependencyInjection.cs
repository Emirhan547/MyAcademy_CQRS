using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Infrastructure.Observeres;
using MyAcademyCQRS.Infrastructure.Persistence.Concrete;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderEventHandler, OrderLogEventHandler>();
            services.AddScoped<IOrderEventHandler, OrderMailEventHandler>();

            return services;
        }
    }
}