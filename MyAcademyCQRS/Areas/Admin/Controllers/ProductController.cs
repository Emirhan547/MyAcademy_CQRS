using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands;
using MyAcademyCQRS.Core.Application.Features.Queries.CategoryQueries;
using MyAcademyCQRS.Core.Application.Features.Queries.ProductQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ProductController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = await mediator.Send(new GetAllProductsQuery());
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await LoadCategoriesAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] CreateProductCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success)
        {
            await LoadCategoriesAsync();
            return View(command);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var model = await mediator.Send(new GetProductByIdQuery { Id = id });
        if (model is null)
        {
            return NotFound();
        }

        await LoadCategoriesAsync();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromForm] UpdateProductCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success)
        {
            await LoadCategoriesAsync();
            return View(command);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int id)
    {
        await mediator.Send(new RemoveProductCommand { Id = id });
        return RedirectToAction(nameof(Index));
    }

    private async Task LoadCategoriesAsync()
    {
        ViewBag.Categories = await mediator.Send(new GetAllCategoriesQuery());
    }
}