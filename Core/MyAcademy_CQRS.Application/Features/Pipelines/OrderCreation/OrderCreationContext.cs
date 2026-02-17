using MyAcademyCQRS.Core.Application.Features.Commands.OrderCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademy_CQRS.Application.Features.Pipelines.OrderCreation
{
    public class OrderCreationContext
    {
        public CreateOrderCommand Command { get; init; } = default!;
        public IList<OrderItem> OrderItems { get; } = new List<OrderItem>();
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public string? FailureReason { get; set; }
        public Order? Order { get; set; }
    }
}