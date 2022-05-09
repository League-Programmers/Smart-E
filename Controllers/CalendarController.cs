using Microsoft.AspNetCore.Mvc;

namespace Smart_E.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Calendar()
        {
            return View();
        }
    }
}
