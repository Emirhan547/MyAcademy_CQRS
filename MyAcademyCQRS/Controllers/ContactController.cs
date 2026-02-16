using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactMessages;

namespace MyAcademyCQRS.Controllers;

public class ContactController(IMediator mediator) : Controller
{
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SendMessage(CreateContactMessageCommand command)
    {
        if (!User.Identity?.IsAuthenticated ?? true)
        {
            return RedirectToDefaultWithStatus("login_required");
        }

        if (!User.IsInRole("User"))
        {
            return RedirectToDefaultWithStatus("forbidden", "Sadece kullanıcı rolündeki hesaplar mesaj gönderebilir.");
        }

        var result = await mediator.Send(command);
        if (!result.Success)
        {
            return RedirectToDefaultWithStatus("error", result.Message);
        }

        return RedirectToDefaultWithStatus("success", result.Message);
    }

    private IActionResult RedirectToDefaultWithStatus(string status, string? message = null)
    {
        var query = new Dictionary<string, string?>
        {
            ["contact"] = "1",
            ["contactStatus"] = status
        };

        if (!string.IsNullOrWhiteSpace(message))
        {
            query["contactMessage"] = message;
        }

        var url = QueryHelpers.AddQueryString(Url.Action("Index", "Default") ?? "/Default/Index", query);
        return Redirect(url);
    }
}