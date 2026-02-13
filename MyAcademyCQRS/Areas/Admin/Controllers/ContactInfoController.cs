using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactInfoCommands;
using MyAcademyCQRS.Core.Application.Features.Queries.ContactInfoQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers;

[Area("Admin")]
public class ContactInfoController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index() => View(await mediator.Send(new GetAllContactInfoQuery()));

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateContactInfoCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success) return View(command);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var model = await mediator.Send(new GetContactInfoByIdQuery { Id = id });
        return model is null ? NotFound() : View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateContactInfoCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success) return View(command);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int id)
    {
        await mediator.Send(new RemoveContactInfoCommand { Id = id });
        return RedirectToAction(nameof(Index));
    }
}