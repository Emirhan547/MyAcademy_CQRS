using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultServiceViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
