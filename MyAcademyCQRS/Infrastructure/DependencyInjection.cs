using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Core.Application;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Infrastructure.Observeres;
using MyAcademyCQRS.Infrastructure.Persistence.Concrete;
using MyAcademyCQRS.Infrastructure.Persistence.Context;
using MyAcademyCQRS.Infrastructure.Storage;

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
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IGalleryCategoryReadRepository, GalleryCategoryReadRepository>();
            services.AddScoped<IImageStorageService, GoogleCloudStorageService>();
            services.AddScoped<IOrderEventHandler, OrderLogEventHandler>();
            services.AddScoped<IOrderEventHandler, OrderMailEventHandler>();

            return services;
        }
    }
}