using FluentValidation;
using MediatR;


namespace MyAcademyCQRS.Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddValidatorsFromAssembly(typeof(ApplicationAssembly).Assembly);


            return services;
        }
    }
}
