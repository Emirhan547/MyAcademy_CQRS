namespace MyAcademyCQRS.Core.Application.Features.Results.OrderItems
{
    public class GetOrderDetailItemQueryResult
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }   // read side convenience
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
