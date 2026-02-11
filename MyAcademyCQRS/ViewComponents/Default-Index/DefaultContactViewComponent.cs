using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultContactViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
