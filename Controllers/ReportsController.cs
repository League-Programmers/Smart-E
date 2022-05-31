using Microsoft.AspNetCore.Mvc;

namespace Smart_E.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Reports()
        {
            return View();
        }
    }
}
