using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademy_CQRS.Application.Features.Commands.CartCommands;
using MyAcademyCQRS.Core.Application.Features.Queries.CartQueries;

namespace MyAcademyCQRS.Controllers
{
    public class CartController(IMediator mediator) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await mediator.Send(new GetCartQuery());
            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int productId, int quantity = 1)
        {
            var result = await mediator.Send(new AddToCartCommand
            {
                ProductId = productId,
                Quantity = quantity
            });

            TempData[result.Success ? "SuccessMessage" : "ErrorMessage"] = result.Message;
            var returnUrl = Request.Headers.Referer.ToString();
            return string.IsNullOrWhiteSpace(returnUrl)
                ? RedirectToAction(nameof(Index))
                : Redirect(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQuantity(int productId, int quantity)
        {
            await mediator.Send(new UpdateCartItemQuantityCommand
            {
                ProductId = productId,
                Quantity = quantity
            });

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int productId)
        {
            await mediator.Send(new RemoveFromCartCommand { ProductId = productId });
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clear()
        {
            await mediator.Send(new ClearCartCommand());
            return RedirectToAction(nameof(Index));
        }
    }
}