using MyAcademyCQRS.Core.Application.Features.Handlers.CategoryHandlers;
using MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers;

namespace MyAcademyCQRS.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddCQRSHandlers(this IServiceCollection services)
        {
            services.AddScoped<GetAllCategoriesQueryHandler>();
           
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();

          
            services.AddScoped<CreateProductCommandHandler>();
         
            services.AddScoped<UpdateProductCommandHandler>();
            services.AddScoped<RemoveProductCommandHandler>();
        }

    }
}
