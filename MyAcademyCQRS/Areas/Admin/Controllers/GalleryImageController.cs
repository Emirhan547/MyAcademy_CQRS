using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Commands.GallerImageCommands;
using MyAcademyCQRS.Core.Application.Features.Queries.GalleryCategoryQueries;
using MyAcademyCQRS.Core.Application.Features.Queries.GalleryImageQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers;

[Area("Admin")]
public class GalleryImageController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = await mediator.Send(new GetActiveGalleryImageQuery());
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await LoadGalleryCategoriesAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateGalleryImageCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success)
        {
            await LoadGalleryCategoriesAsync();
            return View(command);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var model = await mediator.Send(new GetGalleryImageByIdQuery { Id = id });
        if (model is null)
        {
            return NotFound();
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateGalleryImageCommand command)
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
        await mediator.Send(new RemoveGalleryImageCommand { Id = id });
        return RedirectToAction(nameof(Index));
    }

    private async Task LoadGalleryCategoriesAsync()
    {
        ViewBag.GalleryCategories = await mediator.Send(new GetAllGalleryCategoriesQuery());
    }
}