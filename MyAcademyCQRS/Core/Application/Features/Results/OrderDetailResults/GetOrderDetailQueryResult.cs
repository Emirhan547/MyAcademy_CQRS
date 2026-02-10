using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Core.Application.Features.Results.OrderDetailResults
{
    public class GetOrderDetailQueryResult
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }

        public IList<GetOrderDetailItemQueryResult> Items { get; set; } = new List<GetOrderDetailItemQueryResult>();
    }
}
