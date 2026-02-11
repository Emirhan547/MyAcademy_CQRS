using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultOurStoryViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
