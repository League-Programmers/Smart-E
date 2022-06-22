using Microsoft.AspNetCore.Mvc;

namespace Smart_E.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
