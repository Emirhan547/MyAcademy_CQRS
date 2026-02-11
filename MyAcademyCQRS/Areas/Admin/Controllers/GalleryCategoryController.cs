using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Commands.GalleryCategoryCommands;
using MyAcademyCQRS.Core.Application.Features.Queries.GalleryCategoryQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers;

[Area("Admin")]
public class GalleryCategoryController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = await mediator.Send(new GetAllGalleryCategoriesQuery());
        return View(model);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateGalleryCategoryCommand command)
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
        var model = await mediator.Send(new GetGalleryCategoryByIdQuery { Id = id });
        if (model is null)
        {
            return NotFound();
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateGalleryCategoryCommand command)
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
        await mediator.Send(new RemoveGalleryCategoryCommand { Id = id });
        return RedirectToAction(nameof(Index));
    }
}