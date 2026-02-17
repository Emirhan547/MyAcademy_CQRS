using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademy_CQRS.Application.Features.Queries.DashboardQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController(IMediator mediator) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dashboardData = await mediator.Send(new GetAdminDashboardQuery());
            return View(dashboardData);
        }
    }
}
