using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;
using Smart_E.Models.MyChild;
using Smart_E.Models.MyStudent;

namespace Smart_E.Controllers
{
    public class MyStudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public MyStudentsController( ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult MyStudents()
        {
            return View();
        }

        public async Task<IActionResult> MyStudentsProgress([FromQuery] string studentId, [FromQuery] Guid courseId)
        {
            var student = await _context.Users.SingleOrDefaultAsync(x => x.Id == studentId);

            if (student != null)
            {
                var course = await _context.Course.SingleOrDefaultAsync(x => x.Id == courseId);
                return View(new MyStudentsProgressViewModel()
                {
                    Id = student.Id,
                    Name = student.FirstName + " " + student.LastName,
                    CourseId = course.Id,
                    Grade = course.Grade,
                    CourseName = course.CourseName
                });

            }
            else
            {
                return View("Error");
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetAllMyStudentCourses()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var myStudents = await (
                from c in _context.Course
                join mc in _context.MyCourses
                    on c.Id equals mc.CourseId
                join u in _context.Users
                    on mc.StudentId equals u.Id
                where c.TeacherId == user.Id && mc.Status == true
                select new
                {
                    Id = mc.Id,
                    CourseId = c.Id,
                    CourseName = c.CourseName,
                    UserId = u.Id,
                    Email = u.Email,
                    TeacherId = c.TeacherId,
                    Grade = c.Grade,
                    StudentId = mc.StudentId,
                    Student = u.FirstName + " " + u.LastName
                }).ToListAsync();
           
            return Json(myStudents);
        }
    }
}
