namespace MyAcademyCQRS.Core.Domain.Entities
{
    public class Promotion:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
