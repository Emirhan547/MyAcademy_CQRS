using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
