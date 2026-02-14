namespace MyAcademyCQRS.Core.Application.Features.Commands.OrderItemCommands
{
    public class CreateOrderItemCommand
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
