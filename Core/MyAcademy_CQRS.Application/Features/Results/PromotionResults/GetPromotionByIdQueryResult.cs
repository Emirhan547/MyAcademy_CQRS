namespace MyAcademyCQRS.Core.Application.Features.Results.PromotionResults
{
    public class GetPromotionByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
    }
}