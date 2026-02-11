using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.UILayout
{
    public class _UILayoutFooterViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke ()
        {
            return View();
        }
    }
}
