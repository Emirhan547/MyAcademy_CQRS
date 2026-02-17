using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademy_CQRS.Application.Contracts.Services;
using MyAcademy_CQRS.Application.Features.Queries.OrderQueries;
using MyAcademyCQRS.Core.Application.Features.Queries.OrderQueries;
using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Areas.User.Controllers;

[Area("User")]
[Authorize(Roles = "User,Admin")]

public class OrderController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
      
        var orders = await mediator.Send(new GetCurrentUserOrdersForListingQuery());
        return View(orders);
    }
}
