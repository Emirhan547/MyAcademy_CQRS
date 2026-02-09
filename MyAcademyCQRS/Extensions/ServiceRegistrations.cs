using MyAcademyCQRS.Core.Application.Features.Handlers.CategoryHandlers;
using MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers;

namespace MyAcademyCQRS.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddCQRSHandlers(this IServiceCollection services)
        {
            services.AddScoped<GetCategoriesQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();

            services.AddScoped<GetProductQueryHandler>();
            services.AddScoped<CreateProductCommandHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<UpdateProductCommandHandler>();
            services.AddScoped<RemoveProductCommandHandler>();
        }

    }
}
