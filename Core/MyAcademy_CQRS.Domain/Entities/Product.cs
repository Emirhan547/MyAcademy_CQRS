

namespace MyAcademyCQRS.Core.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
    }
}
