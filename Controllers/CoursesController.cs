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

        public IActionResult CourseDetails()
        {
            /*var course = await _context.Course.SingleOrDefaultAsync(x => x.Id == Id);
            var chapter = new List<ChapterViewModel>();
            if (course != null)
            {
                return View(new CourseViewModel
                {
                    Id = course.Id,
                    CourseName = course.CourseName,
                    Chapters = chapter

                });
            }
            else
            {
                return View("Error");
            }*/
            return View();
        }

        public async Task<IActionResult> GetCourses()
        {
            var courses = await (
                from c in _context.Course
                select new
                {
                    CourseName = c.CourseName,
                    Grade = c.Grade

                }).ToListAsync();

            return Json(courses);
        }
        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCoursePostModel model)
        {
            /* if (!(await _userManager.IsInRoleAsync(user, "Administrator")))
                            {
                                throw new Exception($"You are not allowed to add courses, because you don't have the Administrator role assigned to you.");
                            }*/

            if (ModelState.IsValid)
            {
                var existingCourse = await _context.Course.SingleOrDefaultAsync(x => x.CourseName == model.CourseName);

                if (existingCourse == null)
                {
                    var course = new Course()
                    {
                        CourseId = Guid.NewGuid(),
                        CourseName = model.CourseName,
                        Grade = model.Grade
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
