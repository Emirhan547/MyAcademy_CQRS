using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademy_CQRS.Application.Contracts.Services;
using MyAcademyCQRS.Areas.User.Models;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Areas.User.Controllers;

[Area("User")]
[Authorize(Roles = "User,Admin")]
public class OrderController(UserManager<AppUser> userManager, AppDbContext context, IActivityLogService activityLogService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await userManager.GetUserAsync(User);
        if (user is null)
        {
            return RedirectToAction("Login", "Auth", new { area = string.Empty });
        }

        var orders = await context.Orders
            .Include(x => x.OrderItems)
            .Where(x => x.UserId == user.Id)
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();
        await activityLogService.LogAsync(
            ActivityLogCategory.Order,
            "Siparişlerim görüntülendi",
            $"Kullanıcı sipariş listesi sayfasını açtı. Sipariş sayısı: {orders.Count}",
            user.Email,
            user.Id,
            HttpContext.Connection.RemoteIpAddress?.ToString());
        var model = new OrderListViewModel
        {
            Orders = orders
        };

        return View(model);
    }
}