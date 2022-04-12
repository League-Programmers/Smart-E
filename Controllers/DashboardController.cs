using Microsoft.AspNetCore.Mvc;

namespace Smart_E.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
