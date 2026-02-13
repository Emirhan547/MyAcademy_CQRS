using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Models.Auths;


namespace MyAcademyCQRS.Controllers;

public class AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : Controller
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
        return RedirectToAction("Index", "Default", new { area = string.Empty });
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Default", new { area = string.Empty });
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }
}