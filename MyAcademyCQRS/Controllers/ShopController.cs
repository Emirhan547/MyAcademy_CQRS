using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Queries.CategoryQueries;
using MyAcademyCQRS.Core.Application.Features.Queries.ProductQueries;
using MyAcademyCQRS.Models;

namespace MyAcademyCQRS.Controllers
{
    public class ShopController(IMediator mediator) : Controller
    {
        public async Task<IActionResult> Index(int? categoryId)
        {
            ViewBag.Categories = await mediator.Send(new GetActiveCategoriesQuery());
            ViewBag.SelectedCategoryId = categoryId;

            var products = await mediator.Send(new GetShopProductsQuery
            {
                CategoryId = categoryId
            });

            return View(products);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var result = await mediator.Send(new GetShopDetailQuery { Id = id });

            return result is null
                   ? NotFound()
                   : View(result);
        }
    }
}