using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultBannerViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke ()
        {
            return View();
        }
    }
}
