using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Contracts
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderWithItemsAsync(int orderId);
    }
}
