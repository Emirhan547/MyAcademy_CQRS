using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Commands.TestimonialCommands;
using MyAcademyCQRS.Core.Application.Features.Queries.TestimonialQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers;

[Area("Admin")]
public class TestimonialController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = await mediator.Send(new GetAllTestimonialsQuery());
        return View(model);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateTestimonialCommand command)
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
        var model = await mediator.Send(new GetTestimonialByIdQuery { Id = id });
        if (model is null)
        {
            return NotFound();
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateTestimonialCommand command)
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
        await mediator.Send(new RemoveTestimonialCommand { Id = id });
        return RedirectToAction(nameof(Index));
    }
}