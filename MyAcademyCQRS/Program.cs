using Microsoft.AspNetCore.Identity;
using MyAcademyCQRS.Core.Application;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Extensions;
using MyAcademyCQRS.Infrastructure;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddCQRSHandlers();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();
await SeedIdentityAsync(app.Services);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

    app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

static async Task SeedIdentityAsync(IServiceProvider services)
{
    using var scope = services.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    var roles = new[] { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    const string adminEmail = "admin@myacademy.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser is null)
    {
        adminUser = new AppUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            FullName = "System Admin"
        };

        var createResult = await userManager.CreateAsync(adminUser, "Admin123!");
        if (createResult.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}