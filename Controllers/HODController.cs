using Microsoft.AspNetCore.Mvc;

namespace Smart_E.Controllers
{
    public class HODController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Grade()
        {
            return View();
        }
    }
}
