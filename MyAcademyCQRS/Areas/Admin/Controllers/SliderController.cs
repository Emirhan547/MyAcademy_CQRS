
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Commands.SliderCommands;
using MyAcademyCQRS.Core.Application.Features.Queries.SliderQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class SliderController(IMediator mediator) : Controller
{
  
    [HttpGet]
    public async Task<IActionResult> Index()
    {

        var model = await mediator.Send(new GetAllSlidersQuery());
        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] CreateSliderCommand command)
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
        var model = await mediator.Send(new GetSliderByIdQuery { Id = id });
        if (model is null)
        {
            return NotFound();
        }

        return View(model);
    }

          
    [HttpPost]
[ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromForm] UpdateSliderCommand command)
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
        await mediator.Send(new RemoveSliderCommand(id));
        return RedirectToAction(nameof(Index));
    }
}