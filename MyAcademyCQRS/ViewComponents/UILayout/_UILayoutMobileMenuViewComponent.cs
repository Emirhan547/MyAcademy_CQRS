using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.UILayout
{
    public class _UILayoutMobileMenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke ()
        {
            return View();
        }
    }
}
