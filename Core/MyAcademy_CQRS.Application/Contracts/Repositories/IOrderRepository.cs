using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademy_CQRS.Application.Contracts.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderWithItemsAsync(int orderId);
   
    }
}
