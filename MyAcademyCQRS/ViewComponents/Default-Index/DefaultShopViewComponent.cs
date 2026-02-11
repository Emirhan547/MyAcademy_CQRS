using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultShopViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
