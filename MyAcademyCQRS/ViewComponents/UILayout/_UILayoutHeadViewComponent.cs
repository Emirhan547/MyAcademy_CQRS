using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.UILayout
{
    public class _UILayoutHeadViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
