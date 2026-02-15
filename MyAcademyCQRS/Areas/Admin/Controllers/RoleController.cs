using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademy_CQRS.Persistence.Identities;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.Users = userManager.Users.ToList();
        ViewBag.Roles = roleManager.Roles.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        if (!string.IsNullOrWhiteSpace(roleName) && !await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> AssignRole(string userId, string roleName)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user is null || string.IsNullOrWhiteSpace(roleName))
        {
            return RedirectToAction(nameof(Index));
        }

        var userRoles = await userManager.GetRolesAsync(user);
        if (userRoles.Any())
        {
            await userManager.RemoveFromRolesAsync(user, userRoles);
        }

        if (await roleManager.RoleExistsAsync(roleName))
        {
            await userManager.AddToRoleAsync(user, roleName);
        }

        return RedirectToAction(nameof(Index));
    }
}