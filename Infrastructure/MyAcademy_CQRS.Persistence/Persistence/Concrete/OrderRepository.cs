using Microsoft.EntityFrameworkCore;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Infrastructure.Persistence.Concrete
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

       
    }
}
