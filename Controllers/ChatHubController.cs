using Microsoft.AspNetCore.Mvc;

namespace Smart_E.Controllers
{
    public class ChatHubController : Controller
    {
        public IActionResult ChatHub()
        {
            return View();
        }
    }
}
