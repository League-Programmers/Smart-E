using Microsoft.AspNetCore.Mvc;

namespace Smart_E.Controllers
{
    public class MyForumsController : Controller
    {
        public IActionResult MyForums()
        {
            return View();
        }
    }
}
