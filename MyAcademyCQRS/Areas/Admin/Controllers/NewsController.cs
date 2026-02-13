using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Commands.NewsCommands;
using MyAcademyCQRS.Core.Application.Features.Queries.NewsQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class NewsController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index() => View(await mediator.Send(new GetAllNewsQuery()));

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] CreateNewsCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success) return View(command);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var model = await mediator.Send(new GetNewsByIdQuery { Id = id });
        return model is null ? NotFound() : View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromForm] UpdateNewsCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success) return View(command);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int id)
    {
        await mediator.Send(new RemoveNewsCommand { Id = id });
        return RedirectToAction(nameof(Index));
    }
}