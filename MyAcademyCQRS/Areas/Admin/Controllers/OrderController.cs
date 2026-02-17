using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MyAcademyCQRS.Core.Application.Features.Commands.OrderCommands;
using MyAcademyCQRS.Core.Application.Features.Queries.AdminQueries;
using MyAcademyCQRS.Core.Application.Features.Queries.OrderQueries;
using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]

public class OrderController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(string? searchTerm, string? status)
    {
        var model = await mediator.Send(new GetAdminOrderListQuery
        {
            SearchTerm = searchTerm,

            Status = status
        });

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

  
}