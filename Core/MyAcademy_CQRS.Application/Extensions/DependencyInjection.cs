using FluentValidation;
using MediatR;


namespace MyAcademy_CQRS.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ApplicationAssembly).Assembly));

            services.AddValidatorsFromAssemblyContaining<ApplicationAssembly>();

            return services;
        }

    }
}
