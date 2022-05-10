using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> GetCourses()
        {
            var courses = await (
                from c in _context.Course
                select new
                {
                    CourseName = c.CourseName,

                }).ToListAsync();

            return Json(courses);
        }
    }
}
