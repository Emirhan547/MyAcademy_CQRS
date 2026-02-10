namespace MyAcademyCQRS.Core.Domain.Enums
{
    public record OrderStatusChangedEvent(int OrderId, OrderStatus NewStatus);
}
