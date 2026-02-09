using AutoMapper;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;

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
