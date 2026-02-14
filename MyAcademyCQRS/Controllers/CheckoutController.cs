using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademy_CQRS.Application.Features.Commands.CartCommands;
using MyAcademy_CQRS.Domain.Enums;
using MyAcademyCQRS.Core.Application.Features.Queries.CartQueries;
using MyAcademyCQRS.Models;

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

            return View(new CheckoutViewModel
            {
                Cart = cartResult.Data,
                PaymentMethod = PaymentMethodType.CreditCard
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CheckoutViewModel model)
        {
            var cartResult = await mediator.Send(new GetCartQuery());
            model.Cart = cartResult.Data ?? new();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await mediator.Send(new CompleteCheckoutCommand
            {
                FullName = model.FullName,
                Email = model.Email,
                Address = model.Address,
                City = model.City,
                District = model.District,
                PaymentMethod = model.PaymentMethod,
                CardHolderName = model.CardHolderName,
                CardNumber = model.CardNumber,
                ExpireMonth = model.ExpireMonth,
                ExpireYear = model.ExpireYear,
                Cvv = model.Cvv,
                Iban = model.Iban,
                TransferReference = model.TransferReference
            });

            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(model);
            }

            TempData["SuccessMessage"] = result.Message;
            return RedirectToAction("Index", "Order", new { area = "User" });
        }
    }
}