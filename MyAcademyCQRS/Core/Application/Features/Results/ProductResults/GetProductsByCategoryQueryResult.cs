namespace MyAcademyCQRS.Core.Application.Features.Results.ProductResults
{
    public class GetProductsByCategoryQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
    }
}
