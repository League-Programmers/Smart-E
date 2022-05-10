using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;
using Smart_E.Models.Courses;

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
       
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCoursePostModel model)
        {
           
            if (ModelState.IsValid)
            {
                var existingCourse = await _context.Course.SingleOrDefaultAsync(x => x.CourseName == model.CourseName);

                if (existingCourse == null)
                {
                    var course = new Course()
                    {
                        CourseId = Guid.NewGuid(),
                        CourseName = model.CourseName,

                    };
                    await _context.Course.AddAsync(course);

                    await _context.SaveChangesAsync();

                    return Json(course);
                }

                return BadRequest("This Course already Exists");

            }
            return BadRequest("Model is not valid");
        }
    }
}
