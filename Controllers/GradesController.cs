using Microsoft.AspNetCore.Mvc;

namespace Smart_E.Controllers
{
    public class GradesController : Controller
    {
        public IActionResult Grades()
        {
            return View();
        }
    }
}
