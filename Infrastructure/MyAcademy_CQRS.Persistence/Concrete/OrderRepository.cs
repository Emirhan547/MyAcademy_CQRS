using Microsoft.EntityFrameworkCore;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Persistence.Context;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademy_CQRS.Persistence.Concrete
{
    public class OrderRepository (AppDbContext _appDbContext): IOrderRepository
    {
        public async Task<Order?> GetOrderWithItemsAsync(int orderId)
        {
            return await _appDbContext.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<IList<Order>> GetOrdersByUserIdWithItemsAsync(string userId)
        {
            return await _appDbContext.Orders
                .Include(o => o.OrderItems)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedDate)
                .ToListAsync();
        }
    }
}
