namespace MyAcademyCQRS.Core.Application.Features.Results.ProductResults
{
    public class GetProductByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}