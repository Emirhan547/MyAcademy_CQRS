using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Commands.CategoryCommands;
using MyAcademyCQRS.Core.Application.Features.Handlers.CategoryHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.CategoryQueries;


namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly GetCategoriesQueryHandler _handler;
        private readonly GetCategoryByIdQueryHandler _queryHandler;
        private readonly UpdateCategoryCommandHandler _updateCategory;
        private readonly CreateCategoryCommandHandler _createCategory;
        private readonly RemoveCategoryCommandHandler _removeCategory;
        public CategoryController(GetCategoriesQueryHandler handler, GetCategoryByIdQueryHandler queryHandler, UpdateCategoryCommandHandler updateCategory, RemoveCategoryCommandHandler removeCategory, CreateCategoryCommandHandler createCategory)
        {
            _handler = handler;
            _queryHandler = queryHandler;
            _updateCategory = updateCategory;
            _removeCategory = removeCategory;
            _createCategory = createCategory;
        }

        public async Task <IActionResult> Index()
        {
            var categories = await _handler.Handle();
            return View(categories);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>CreateCategory(CreateCategoryCommand command)
        {
            await _createCategory.Handle(command);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _queryHandler.Handle(new GetCategoryByIdQuery(id));
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult>UpdateCategory(UpdateCategoryCommand update)
        {
            await _updateCategory.Handle(update);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>DeleteCategory(int id)
        {
            await _removeCategory.Handle(new RemoveCategoryCommand(id));
            return RedirectToAction("Index");
        }
    }
}
