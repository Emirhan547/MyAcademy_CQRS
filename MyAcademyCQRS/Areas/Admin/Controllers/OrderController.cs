using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademy_CQRS.Persistence.Context;
using MyAcademyCQRS.Areas.Admin.Models;
using MyAcademyCQRS.Core.Application.Features.Commands.OrderCommands;
using MyAcademyCQRS.Core.Application.Features.Queries.OrderQueries;
using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class OrderController(IMediator mediator, AppDbContext context) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(string? searchTerm, string? status)
    {
        var orders = await mediator.Send(new GetAllOrdersQuery());

        var userIds = orders.Where(x => !string.IsNullOrWhiteSpace(x.UserId)).Select(x => x.UserId!).Distinct().ToList();
        var users = await context.Users
            .Where(user => userIds.Contains(user.Id))
            .Select(user => new CustomerIdentityInfo
            {
                Id = user.Id,
                Name = string.IsNullOrWhiteSpace(user.FullName) ? user.UserName ?? "Misafir" : user.FullName,
                Email = user.Email ?? "-"
            })
            .ToListAsync();

        var userLookup = users.ToDictionary(user => user.Id, user => user);

        var query = orders.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(order => order.Status.ToString().Equals(status, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(order =>
                order.OrderNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                ResolveCustomerName(order.UserId, userLookup).Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        var filteredOrders = query.OrderByDescending(order => order.CreatedDate).ToList();

        var model = new AdminOrderListViewModel
        {
            SearchTerm = searchTerm,
            Status = status,
            TotalOrderCount = filteredOrders.Count,
            TotalRevenue = filteredOrders.Sum(order => order.TotalPrice),
            Orders = filteredOrders.Select(order => new AdminOrderListItemViewModel
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                CustomerName = ResolveCustomerName(order.UserId, userLookup),
                CustomerEmail = ResolveCustomerEmail(order.UserId, userLookup),
                TotalPrice = order.TotalPrice,
                Status = order.Status.ToString(),
                CreatedDate = order.CreatedDate
            }).ToList()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Approve(int orderId, string? searchTerm, string? status)
    {
        var result = await mediator.Send(new UpdateOrderStatusCommand
        {
            OrderId = orderId,
            Status = OrderStatus.Approved
        });

        TempData[result.Success ? "OrderSuccess" : "OrderError"] = result.Message;
        return RedirectToAction(nameof(Index), new { searchTerm, status });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(int orderId, string? searchTerm, string? status)
    {
        var result = await mediator.Send(new UpdateOrderStatusCommand
        {
            OrderId = orderId,
            Status = OrderStatus.Cancelled
        });

        TempData[result.Success ? "OrderSuccess" : "OrderError"] = result.Message;
        return RedirectToAction(nameof(Index), new { searchTerm, status });
    }

    private static string ResolveCustomerName(string? userId, IReadOnlyDictionary<string, CustomerIdentityInfo> userLookup)
    {
        if (string.IsNullOrWhiteSpace(userId) || !userLookup.TryGetValue(userId, out var user))
        {
            return "Misafir";
        }

        return user.Name;
    }

    private static string ResolveCustomerEmail(string? userId, IReadOnlyDictionary<string, CustomerIdentityInfo> userLookup)
    {
        if (string.IsNullOrWhiteSpace(userId) || !userLookup.TryGetValue(userId, out var user))
        {
            return "-";
        }

        return user.Email;
    }

    private sealed class CustomerIdentityInfo
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}