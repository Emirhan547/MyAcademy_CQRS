using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademy_CQRS.Application.Features.Commands.CartCommands;
using MyAcademy_CQRS.Domain.Enums;
using MyAcademyCQRS.Core.Application.Features.Queries.CartQueries;


namespace MyAcademyCQRS.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class CheckoutController(IMediator mediator) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cartResult = await mediator.Send(new GetCartQuery());
            if (cartResult.Data is null || !cartResult.Data.Items.Any())
            {
                TempData["ErrorMessage"] = "Ödeme için sepetinize ürün ekleyin.";
                return RedirectToAction("Index", "Cart");
            }

            ViewBag.Cart = cartResult.Data;
            return View(new CompleteCheckoutCommand
            {
             
                PaymentMethod = PaymentMethodType.CreditCard
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CompleteCheckoutCommand command)
        {
            var cartResult = await mediator.Send(new GetCartQuery());
            ViewBag.Cart = cartResult.Data ?? new();

            if (!ModelState.IsValid)
            {
                return View(command);
            }

            var result = await mediator.Send(command);

            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(command);
            }

            TempData["SuccessMessage"] = result.Message;
            return RedirectToAction("Index", "Order", new { area = "User" });
        }
    }
}