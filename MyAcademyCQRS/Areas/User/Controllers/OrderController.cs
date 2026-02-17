

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademy_CQRS.Application.Contracts.Services;

using MyAcademyCQRS.Core.Application.Features.Queries.OrderQueries;
using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Areas.User.Controllers;

[Area("User")]
[Authorize(Roles = "User,Admin")]
public class OrderController(IMediator mediator, IActivityLogService activityLogService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        if (User.Identity?.IsAuthenticated != true)
        {
            return RedirectToAction("Login", "Auth", new { area = string.Empty });
        }

        var orders = await mediator.Send(new GetCurrentUserOrdersQuery());
        await activityLogService.LogAsync(
            ActivityLogCategory.Order,
            "Siparişlerim görüntülendi",
            $"Kullanıcı sipariş listesi sayfasını açtı. Sipariş sayısı: {orders.Count}",
             ipAddress: HttpContext.Connection.RemoteIpAddress?.ToString());
       

        return View(orders);
    }
}