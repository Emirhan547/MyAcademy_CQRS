using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Behaviors;

namespace MyAcademyCQRS.Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
