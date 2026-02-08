using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;
using MyAcademyCQRS.Entities;

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
