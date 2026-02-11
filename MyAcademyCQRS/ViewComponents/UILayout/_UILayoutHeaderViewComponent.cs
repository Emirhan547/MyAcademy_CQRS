using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.UILayout
{
    public class _UILayoutHeaderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
