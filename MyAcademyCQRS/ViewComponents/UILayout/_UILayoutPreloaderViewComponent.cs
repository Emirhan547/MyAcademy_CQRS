using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.UILayout
{
    public class _UILayoutPreloaderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
