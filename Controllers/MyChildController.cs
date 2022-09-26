using DocumentFormat.OpenXml.Office2010.Word;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;
using Smart_E.Models.MyChild;
using Smart_E.Models.MyStudent;

namespace Smart_E.Controllers
{
    public class MyChildController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MyChildController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> MyChildsProgress([FromQuery] string id)
        {
            var child = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (child != null)
            {
                return View(new MyChildsProgressViewModel()
                {
                    Id = child.Id,
                    Name = child.FirstName + " " + child.LastName,

                });

            }
            else
            {
                return View("Error");
            }

        }
        public async Task<IActionResult> MyChildsSubjectProgress([FromQuery] string studentId, [FromQuery] Guid courseId)
        {
            var student = await _context.Users.SingleOrDefaultAsync(x => x.Id == studentId);

            if (student != null)
            {
                var course = await _context.Course.SingleOrDefaultAsync(x => x.Id == courseId);

                if (course != null)
                {
                    var teacher = await _context.Users.SingleOrDefaultAsync(x => x.Id == course.TeacherId);
                    if (teacher != null)
                    {
                        return View(new MyStudentsProgressViewModel()
                        {
                            Id = student.Id,
                            Name = student.FirstName + " " + student.LastName,
                            CourseId = course.Id,
                            Grade = course.Grade,
                            CourseName = course.CourseName,
                            TeacherId = course.TeacherId,
                            TeacherName = teacher.FirstName + " " + teacher.LastName
                        });
                    }
                   
                }

                return BadRequest("Course not found");

            }
            else
            {
                return View("Error");
            }

        }

        public async Task<IActionResult> GetMyChildsSubjects([FromQuery] string studentId)
        {
            var student = await (
                from u in _context.Users
                join mc in _context.MyCourses
                    on u.Id equals mc.StudentId 
                    join c in _context.Course
                    on mc.CourseId equals c.Id
                where u.Id == studentId && mc.Status == true 
                select new
                {
                    Id = mc.Id,
                    StudentId = u.Id,
                    SubjectName = c.CourseName,
                    CourseId = c.Id,
                }).ToListAsync();

            return Json(student);

        }

        public IActionResult MyChild()
        {
            return View();
        }

        public async Task<IActionResult>GetChildren()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var children = await (
                from i in _context.Invites
                join u in _context.Users
                    on i.InviteFrom equals u.Id
                where i.Status == true && i.InviteTo == user.Id
                select new
                {
                    Id = i.InviteFrom,
                    Name = u.FirstName + " "+ u.LastName,

                }).ToListAsync();

            return Json(children);

        }

        public async Task<IActionResult> GetChild([FromQuery]string id)
        {
            var child = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            return Json(child);
        }
    }
}
