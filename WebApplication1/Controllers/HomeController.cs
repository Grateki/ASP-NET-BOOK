using Microsoft.AspNetCore.Mvc;

namespace ControleDeLivros.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
