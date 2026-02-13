using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Areas.User.Models;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Areas.User.Controllers;

[Area("User")]
[Authorize(Roles = "User,Admin")]
public class OrderController(UserManager<AppUser> userManager, AppDbContext context) : Controller
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

        var model = new OrderListViewModel
        {
            Orders = orders
        };

        return View(model);
    }
}