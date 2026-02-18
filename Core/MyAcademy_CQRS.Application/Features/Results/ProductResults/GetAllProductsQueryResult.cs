namespace MyAcademyCQRS.Core.Application.Features.Results.ProductResults
{
    public class GetAllProductsQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }

}
