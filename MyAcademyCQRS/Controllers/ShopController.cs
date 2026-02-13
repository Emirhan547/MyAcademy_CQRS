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
            var categories = await mediator.Send(new GetActiveCategoriesQuery());

            var model = new ShopIndexViewModel
            {
                Categories = categories,
                SelectedCategoryId = categoryId
            };

            if (categoryId.HasValue)
            {
                var productsByCategory = await mediator.Send(new GetProductsByCategoryQuery
                {
                    CategoryId = categoryId.Value
                });

                model.Products = productsByCategory
                    .Select(x => new ShopProductItemViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ImageUrl = x.ImageUrl,
                        Price = x.Price,
                        Rating = x.Rating
                    })
                    .ToList();
            }
            else
            {
                var activeProducts = await mediator.Send(new GetActiveProductsQuery());

                model.Products = activeProducts
                    .Select(x => new ShopProductItemViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ImageUrl = x.ImageUrl,
                        Price = x.Price,
                        Rating = x.Rating
                    })
                    .ToList();
            }

            return View(model);
        }
    }
}