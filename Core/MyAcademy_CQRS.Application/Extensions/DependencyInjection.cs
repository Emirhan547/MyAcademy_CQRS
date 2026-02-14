using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;


namespace MyAcademy_CQRS.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ApplicationAssembly).Assembly));

            services.AddValidatorsFromAssemblyContaining<ApplicationAssembly>();
            services.AddAutoMapper(typeof(ApplicationAssembly).Assembly);

            return services;
        }

    }
}
