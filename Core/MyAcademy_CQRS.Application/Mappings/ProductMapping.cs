using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands;
using MyAcademyCQRS.Core.Application.Features.Results.ProductResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();

            // Read side
            CreateMap<Product, GetAllProductsQueryResult>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name));

            CreateMap<Product, GetActiveProductsQueryResult>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name));

            CreateMap<Product, GetProductsByCategoryQueryResult>();
            CreateMap<Product, GetProductByIdQueryResult>();

        }
    }
}
