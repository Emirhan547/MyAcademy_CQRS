using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Infrastructure.Persistence.Context;
using MyAcademyCQRS.Models.Auths;


namespace MyAcademyCQRS.Areas.User.Controllers;

[Area("User")]
[Authorize(Roles = "User,Admin")]
public class ProfileController(UserManager<AppUser> userManager, AppDbContext context) : Controller
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

        var model = new ProfileViewModel
        {
            FullName = user.FullName,
            Email = user.Email ?? string.Empty,
            PhoneNumber = user.PhoneNumber ?? string.Empty,
            Orders = orders
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ProfileViewModel model)
    {
        var user = await userManager.GetUserAsync(User);
        if (user is null)
        {
            return RedirectToAction("Login", "Auth", new { area = string.Empty });
        }

        user.FullName = model.FullName;
        user.PhoneNumber = model.PhoneNumber;

        await userManager.UpdateAsync(user);
        return RedirectToAction(nameof(Index));
    }
}