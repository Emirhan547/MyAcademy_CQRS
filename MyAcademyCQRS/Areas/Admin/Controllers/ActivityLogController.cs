using MediatR;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademy_CQRS.Persistence.Context;

using MyAcademyCQRS.Core.Application.Features.Queries.AdminQueries;
using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]

public class ActivityLogController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(ActivityLogCategory? category)
    {
       
        var model = await mediator.Send(new GetActivityLogListQuery { Category = category });
        return View(model);
    }
}
