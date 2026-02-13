using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Commands.ServiceCommands;
using MyAcademyCQRS.Core.Application.Features.Queries.ServiceQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ServiceController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = await mediator.Send(new GetAllServicesQuery());
        return View(model);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateServiceCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success)
        {
            return View(command);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var model = await mediator.Send(new GetServiceByIdQuery { Id = id });
        if (model is null)
        {
            return NotFound();
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateServiceCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success)
        {
            return View(command);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int id)
    {
        await mediator.Send(new RemoveServiceCommand { Id = id });
        return RedirectToAction(nameof(Index));
    }
}