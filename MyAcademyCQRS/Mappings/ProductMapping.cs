using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands;
using MyAcademyCQRS.Core.Application.Features.Results.ProductResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
           CreateMap<Product,GetProductsQueryResult>(); 
           CreateMap<CreateProductCommand,Product>(); 
           CreateMap<Product,GetProductByIdQueryResult>(); 
           CreateMap<UpdateProductCommand,Product>(); 

        }
    }
}
