using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands;
using MyAcademyCQRS.Core.Application.Features.Handlers.CategoryHandlers;
using MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.ProductQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(GetProductQueryHandler _getProductQueryHandler,GetAllCategoriesQueryHandler getCategoriesQueryHandler,CreateProductCommandHandler createProductCommandHandler,UpdateProductCommandHandler updateProductCommand,RemoveProductCommandHandler removeProductCommandHandler,GetActiveProductsQueryHandler getProducyByIdQueryHandler) : Controller
    {

        private async Task GetCategoriesAsync()
        {
            var categories = await getCategoriesQueryHandler.Handle();
            ViewBag.categories=(from x in categories select new SelectListItem
            {
                Text=x.Name,
                Value=x.Id.ToString(),
            }).ToList();
        }
        public async Task<IActionResult> Index()
        {
            var products = await _getProductQueryHandler.Handle();
            return View(products);
        }
        public async Task<IActionResult>CreateProduct()
        {
            await GetCategoriesAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>CreateProduct(CreateProductCommand command)
        {
            await createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult>UpdateProduct(int id)
        {
            await GetCategoriesAsync();
            var product = await getProducyByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult>UpdateProduct(UpdateProductCommand command)
        {
            await updateProductCommand.Handle(command);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>DeleteProduct(int id)
        {
            await removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }
    }
}
