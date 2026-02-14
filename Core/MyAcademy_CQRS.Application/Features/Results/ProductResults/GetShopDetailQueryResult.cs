namespace MyAcademyCQRS.Core.Application.Features.Results.ProductResults
{
    public class GetShopDetailQueryResult
    {
        public GetProductByIdQueryResult Product { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public IList<GetActiveProductsQueryResult> RelatedProducts { get; set; } = [];
    }
}