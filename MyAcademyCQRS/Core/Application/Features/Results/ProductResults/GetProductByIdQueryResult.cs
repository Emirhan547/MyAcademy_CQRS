namespace MyAcademyCQRS.Core.Application.Features.Results.ProductResults
{
    public record GetProductByIdQueryResult(int Id, string Name, string Description, decimal Price, string ImageUrl, int CategoryId);

}
