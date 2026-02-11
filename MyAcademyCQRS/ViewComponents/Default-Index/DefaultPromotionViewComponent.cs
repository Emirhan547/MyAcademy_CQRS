using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultPromotionViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
