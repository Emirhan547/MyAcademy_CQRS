using MyAcademyCQRS.Core.Application.Features.Results.CategoryResults;

namespace MyAcademyCQRS.Core.Application.Features.Results.ProductResults
{
    public record GetProductsQueryResult(int Id,string Name,string Description,decimal Price,string ImageUrl,int CategoryId,GetCategoriesQueryResult Category);

}
