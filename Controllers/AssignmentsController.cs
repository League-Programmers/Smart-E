using Microsoft.AspNetCore.Mvc;

namespace Smart_E.Controllers
{
    public class AssignmentsController : Controller
    {
        public IActionResult MyAssignments()
        {
            return View();
        }

        public async Task<IActionResult> GetMyAssignments()
        {

        }
    }
}
