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
public class ProfileController(UserManager<AppUser> userManager) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await userManager.GetUserAsync(User);
        if (user is null)
        {
            return RedirectToAction("Login", "Auth", new { area = string.Empty });
        }

      

        var model = new ProfileViewModel
        {
            FullName = user.FullName,
            Email = user.Email ?? string.Empty,
            PhoneNumber = user.PhoneNumber ?? string.Empty
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