using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactMessages;
using MyAcademyCQRS.Core.Application.Features.Queries.ContactMessageQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ContactMessageController(IMediator mediator) : Controller
{
    public async Task<IActionResult> Index()
    {
        var model = await mediator.Send(new GetAllContactMessagesQuery());
        return View(model);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateContactMessageCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success)
        {
            ModelState.AddModelError(string.Empty, result.Message);
            return View(command);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var model = await mediator.Send(new GetContactMessageByIdQuery { Id = id });
        if (model is null) return NotFound();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateContactCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success)
        {
            ModelState.AddModelError(string.Empty, result.Message);
            return View(command);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int id)
    {
        await mediator.Send(new RemoveContactMessageCommand { Id = id });
        return RedirectToAction(nameof(Index));
    }
}