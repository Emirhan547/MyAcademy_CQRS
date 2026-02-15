using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademy_CQRS.Application.Contracts.Services;
using MyAcademy_CQRS.Persistence.Identities;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Core.Domain.Enums;
using MyAcademyCQRS.Models.Auths;


namespace MyAcademyCQRS.Controllers;

public class AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IActivityLogService activityLogService) : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await userManager.FindByEmailAsync(model.Email);
        if (user is null)
        {
            ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
            return View(model);
        }

        var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
        if (!result.Succeeded)
        {
            ModelState.AddModelError(string.Empty, "Email veya şifre hatalı.");
            return View(model);
            await activityLogService.LogAsync(
            ActivityLogCategory.Auth,
            "Sisteme giriş",
            "Kullanıcı başarılı giriş yaptı.",
            user.Email,
            user.Id,
            HttpContext.Connection.RemoteIpAddress?.ToString());
        }

        if (await userManager.IsInRoleAsync(user, "Admin"))
        {
            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }

        return RedirectToAction("Index", "Default", new { area = string.Empty });
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (model.Password != model.ConfirmPassword)
        {
            ModelState.AddModelError(string.Empty, "Şifreler eşleşmiyor.");
            return View(model);
        }

        var user = new AppUser
        {
            Email = model.Email,
            UserName = model.Email,
            FullName = model.FullName
        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        await userManager.AddToRoleAsync(user, "User");
        await signInManager.SignInAsync(user, false);
        await activityLogService.LogAsync(
            ActivityLogCategory.Registration,
            "Yeni kullanıcı kaydı",
            "Sistem üzerinden yeni kullanıcı kaydı tamamlandı.",
            user.Email,
            user.Id,
            HttpContext.Connection.RemoteIpAddress?.ToString());
        return RedirectToAction("Index", "Default", new { area = string.Empty });
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        var user = await userManager.GetUserAsync(User);
        await signInManager.SignOutAsync();
        await activityLogService.LogAsync(
            ActivityLogCategory.Auth,
            "Sistemden çıkış",
            "Kullanıcı güvenli çıkış yaptı.",
            user?.Email,
            user?.Id,
            HttpContext.Connection.RemoteIpAddress?.ToString());
        return RedirectToAction("Index", "Default", new { area = string.Empty });
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }
}