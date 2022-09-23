using System.Threading.Tasks.Dataflow;
using DocumentFormat.OpenXml.Math;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;
using Smart_E.Models.Assignment;

namespace Smart_E.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public AssignmentsController( ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult MyAssignments()
        {
            return View();
        }

        public async Task<IActionResult> GetAllMyStudentsAssignment([FromQuery] Guid courseId, [FromQuery] string studentId)
        {
            var getAllMyStudentsAssignment = await (
                from c in _context.Course
                join a in _context.Assignments
                    on c.Id equals a.CourseId
                    join mc in _context.MyCourses
                    on a.Id equals mc.AssignmentId
                where c.Id == courseId && mc.StudentId == studentId
                select new
                {
                    Id = a.Id,
                    CourseId = c.Id,
                    AssignmentName = a.Name,
                    AssignmentMark = a.Mark,
                    StudentId = mc.StudentId,
                    CourseName = c.CourseName,
                    NewMark = mc.NewMark
                }).ToListAsync();

            return Json(getAllMyStudentsAssignment);
        }

        public async Task<IActionResult> GetMyStudentsAssignmentMark([FromQuery] Guid assignmentId, [FromQuery] string studentId)
        {
            var myAssignment = await (
                from mc in _context.MyCourses
                join a in _context.Assignments
                    on mc.AssignmentId equals a.Id
                    where mc.StudentId == studentId && a.Id ==assignmentId
                select new
                {
                    Id = a.Id,
                    AssignmentName = a.Name,
                    AssignmentMark = a.Mark,
                    NewMark = mc.NewMark

                }).SingleOrDefaultAsync();
            return Json(myAssignment);
        }

        public async Task<IActionResult> GetMyAssignments()
        {
            var user = await _userManager.GetUserAsync(User);

            var myAssignments = await (
                from c in _context.Course
                join a in _context.Assignments
                    on c.Id equals a.CourseId
                    join u in _context.Users
                    on c.TeacherId equals u.Id
                where c.TeacherId == user.Id
                select new
                {
                    Id = a.Id,
                    Mark = a.Mark,
                    Name = a.Name, 
                    CourseId = c.Id,
                    Grade = c.Grade,
                    CourseName = c.CourseName + " - " +c.Grade,
                    Teacher = c.TeacherId

                }).ToListAsync();

            return Json(myAssignments);
        }

        public async Task<IActionResult> UpdateAssignment([FromBody] UpdateAssignmentPostModal modal, [FromQuery] string studentId, [FromQuery] Guid courseId)
        {
            if (ModelState.IsValid)
            {
                var assignment = await _context.Assignments.SingleOrDefaultAsync(x => x.Id == modal.Id);

                if (assignment != null)
                {
                    var student = await _context.Users.SingleOrDefaultAsync(x => x.Id == studentId);

                    if (student != null)
                    {
                        var myCourse = await _context.MyCourses.SingleOrDefaultAsync(x =>
                            x.StudentId == studentId && x.AssignmentId == assignment.Id && x.CourseId == courseId);
                        if (myCourse != null)
                        {
                            myCourse.NewMark = modal.AssignmentNewMark;

                            _context.MyCourses.Update(myCourse);

                            await _context.SaveChangesAsync();

                            return Json(myCourse);

                        }

                        return BadRequest("New mark can not be inserted");

                    }
                    return BadRequest("Student not found");

                }

                return BadRequest("Assignment not found");
            }

            return BadRequest("Model not found");
        }
        public async Task<IActionResult> CreateAssignment([FromBody] CreateAssignmentPostModal modal)
        {
            if (ModelState.IsValid)
            {
                var course = await _context.Course.SingleOrDefaultAsync(x => x.Id == modal.Course);

                if (course != null)
                {
                    var existingAssignment = await _context.Assignments.SingleOrDefaultAsync(x => x.Name == modal.Name && x.Mark == modal.Mark && x.CourseId == course.Id);
                    if (existingAssignment == null)
                    {
                        var newAssignment = new Assignments()
                        {
                            Id = Guid.NewGuid(),
                            Name = modal.Name,
                            Mark = modal.Mark,
                            CourseId = course.Id,
                        };

                        await _context.Assignments.AddAsync(newAssignment);
                        await _context.SaveChangesAsync();

                        return Json(newAssignment);

                    }
                    return BadRequest("There is already an Assignment with the same information");
                }
                return BadRequest("Course not found");

                
            }

            return BadRequest("Modal not found");
        }

        public async Task<IActionResult> GetMyCourses()
        {
            var user = await _userManager.GetUserAsync(User);
            var myCourses = await (
                from c in _context.Course
                join u in _context.Users
                    on c.TeacherId equals u.Id
                    where c.TeacherId == user.Id
                select new
                {
                    Id = c.Id,
                    Name = c.CourseName,
                    Grade = c.Grade,
                    TeacherId = c.TeacherId
                }).ToListAsync();

            return Json(myCourses);
        }
    }
}
