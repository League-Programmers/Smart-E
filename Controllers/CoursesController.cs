using Microsoft.AspNetCore.Mvc;
using Smart_E.Data;

namespace Smart_E.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Courses()
        {
            return View();
        }

    }
}
