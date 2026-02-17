using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademy_CQRS.Persistence.Context;
using MyAcademyCQRS.Areas.Admin.Models;
using MyAcademyCQRS.Core.Application.Features.Queries.ContactMessageQueries;
using MyAcademyCQRS.Core.Application.Features.Queries.OrderQueries;
using MyAcademyCQRS.Core.Application.Features.Queries.ProductQueries;
using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController(IMediator mediator, AppDbContext context) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await mediator.Send(new GetAllOrdersQuery());
            var products = await mediator.Send(new GetAllProductsQuery());
            var contactMessages = await mediator.Send(new GetAllContactMessagesQuery());

            var userIds = orders.Where(x => !string.IsNullOrWhiteSpace(x.UserId)).Select(x => x.UserId!).Distinct().ToList();
            var userLookup = await context.Users
                .Where(user => userIds.Contains(user.Id))
                .ToDictionaryAsync(user => user.Id, user => string.IsNullOrWhiteSpace(user.FullName) ? user.UserName ?? "Misafir" : user.FullName);

            var weekStart = DateTime.Today.AddDays(-6);
            var weeklyRevenue = Enumerable.Range(0, 7)
                .Select(index => weekStart.AddDays(index))
                .Select(day => new DashboardDailyRevenueItem
                {
                    DayLabel = day.ToString("ddd"),
                    Revenue = orders.Where(order => order.CreatedDate.Date == day.Date).Sum(order => order.TotalPrice)
                })
                .ToList();

            var todayOrders = orders.Where(order => order.CreatedDate.Date == DateTime.Today).ToList();

            var model = new AdminDashboardViewModel
            {
                TotalOrderCount = orders.Count,
                TotalRevenue = orders.Sum(order => order.TotalPrice),
                ActiveProductCount = products.Count(product => product.IsActive),
                ActiveMessageCount = contactMessages.Count(message => message.IsActive),
                PendingOrderCount = orders.Count(order => order.Status == OrderStatus.Pending),
                ApprovedOrderCount = orders.Count(order => order.Status == OrderStatus.Approved),
                CancelledOrderCount = orders.Count(order => order.Status == OrderStatus.Cancelled),
                NewOrdersToday = todayOrders.Count,
                TodayRevenue = todayOrders.Sum(order => order.TotalPrice),
                WeeklyRevenue = weeklyRevenue,
                RecentOrders = orders
                .OrderByDescending(order => order.CreatedDate)
                .Take(8)
                .Select(order => new DashboardRecentOrderItem
                {
                    Id = order.Id,
                    OrderNumber = order.OrderNumber,
                    CustomerName = ResolveCustomerName(order.UserId, userLookup),
                    TotalPrice = order.TotalPrice,
                    CreatedDate = order.CreatedDate,
                    Status = order.Status.ToString()
                })
                .ToList(),
                TopProducts = products
                .Where(product => product.IsActive)
                .OrderByDescending(product => product.Rating)
                .ThenByDescending(product => product.Price)
                .Take(5)
                .Select(product => new DashboardTopProductItem
                {
                    Name = product.Name,
                    CategoryName = product.CategoryName,
                    Price = product.Price,
                    Rating = product.Rating
                })
                .ToList(),
                RecentMessages = contactMessages
                .OrderByDescending(message => message.CreatedDate)
                .Take(5)
                .Select(message => new DashboardRecentMessageItem
                {
                    FullName = message.FullName,
                    Subject = message.Subject,
                    CreatedDate = message.CreatedDate
                })
                .ToList()
            };

            return View(model);
        }

        private static string ResolveCustomerName(string? userId, IReadOnlyDictionary<string, string> userLookup)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return "Misafir";
            }

            return userLookup.TryGetValue(userId, out var customerName) ? customerName : "Bilinmeyen Kullanıcı";
        }
    }
}