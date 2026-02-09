
using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Core.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }

        public IList<OrderItem> OrderItems { get; set; }
    }

}
