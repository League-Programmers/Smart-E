using System.Threading.Tasks.Dataflow;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Office2010.Word.Drawing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
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
        public IActionResult GetAllMyAssignmentMarks()
        {
            return View();
        }
        public async Task<IActionResult> UpdateOutstandingAssignment([FromQuery] Guid id, [FromQuery] bool outstanding)
        {
            var assignmentResult = await _context.AssignmentResults.SingleOrDefaultAsync(x => x.Id == id);

            if (assignmentResult != null)
            {
                assignmentResult.Outstanding = outstanding;
                assignmentResult.NewMark = 0;

                _context.AssignmentResults.Update(assignmentResult);

                await _context.SaveChangesAsync();

                return Json(assignmentResult);

            }

            return BadRequest("Assignment on this student not found");

        }
        public async Task<IActionResult> GetMyPersonalAssignmentMarks()
        {
            var user = await _userManager.GetUserAsync(User);

            var myAssignments = await (
               
                from ar in _context.AssignmentResults
                where ar.StudentId == user.Id
                join a in _context.Assignments
                    on ar.AssignmentId equals a.Id
                    join c in _context.Course
                    on a.CourseId equals c.Id
                select new
                {
                    Id = a.Id,
                    Mark = a.Mark,
                    Name = a.Name, 
                    NewMark = ar.NewMark,
                    Weight = a.Weight,
                    CourseId = c.Id,
                    Grade = c.Grade,
                    CourseName = c.CourseName + " - " +c.Grade,
                }).ToListAsync();

            return Json(myAssignments);

        }
        public async Task<IActionResult> DeleteAssignment([FromQuery] Guid id)
        {
            var assignment = await _context.Assignments.SingleOrDefaultAsync(x => x.Id == id);

            if (assignment != null)
            {
                var assignmentResults = await _context.AssignmentResults.Where(x => x.AssignmentId == assignment.Id)
                    .ToListAsync();

                foreach (var aResults in assignmentResults)
                {
                    _context.AssignmentResults.RemoveRange(aResults);
                    await _context.SaveChangesAsync();

                }

                 _context.Assignments.Remove(assignment);
                 await _context.SaveChangesAsync();

                 return Json(assignment);

            }

            return BadRequest("Assignment not found");
        }


        public async Task<IActionResult> GetMyAssignment([FromQuery] Guid id)
        {
            var assignment = await _context.Assignments.SingleOrDefaultAsync(x => x.Id == id);

            return Json(assignment);
        }
        public async Task<IActionResult> GetAllMyChildsAssignment([FromQuery] string studentId, [FromQuery] Guid courseId )
        {
            var getAllMyStudentAssignments = await (
                from  ar in _context.AssignmentResults
                where ar.StudentId == studentId 
                join a in _context.Assignments
                    on ar.AssignmentId equals a.Id
                    join c in _context.Course
                    on a.CourseId equals c.Id
                where a.CourseId == courseId 
                select new
                {
                    Id = ar.Id,
                    AssignmentId = a.Id,
                    AssignmnetResult = ar.Id,
                    AssignmentName = a.Name,
                    AssignmentMark = a.Mark,
                    Weight = a.Weight,
                    NewMark = ar.NewMark,
                    Percentage = ((ar.NewMark / a.Mark) * 100) + " %",
                    Outcome =  ((ar.NewMark / a.Mark) * 100)<= 49 ? "<label style=\"font-size: 14px; \" class=\"label label-danger\">FAIL</label>"  : "<label style=\"font-size: 14px; \" class=\"label label-success\">PASS</label>" ,
                    StudentId = ar.StudentId,
                    WeightMark = (a.Weight / 100) * ar.NewMark,
                    CourseId = a.CourseId,
                    Outstanding = ar.Outstanding
                }).ToListAsync();
           

            return Json(getAllMyStudentAssignments);

        }
        public async Task<IActionResult> GetAllMyChildsOutstandingAssignment([FromQuery] string studentId, [FromQuery] Guid courseId )
        {
            var getAllMyStudentAssignments = await (
                from  ar in _context.AssignmentResults
                where ar.StudentId == studentId 
                join a in _context.Assignments
                    on ar.AssignmentId equals a.Id
                where ar.Outstanding ==true
                join c in _context.Course
                    on a.CourseId equals c.Id
                where a.CourseId == courseId 
                select new
                {
                    Id = ar.Id,
                    AssignmentId = a.Id,
                    AssignmnetResult = ar.Id,
                    AssignmentName = a.Name,
                    AssignmentMark = a.Mark,
                    Date = a.ExpireDate.ToString("yyyy MMMM dd"),
                    Weight = a.Weight,
                    NewMark =0,
                    Percentage = ((ar.NewMark / a.Mark) * 100) + " %",
                    Outcome =  ((ar.NewMark / a.Mark) * 100)== 0 ? "<label style=\"font-size: 14px; \" class=\"label label-danger\">OUTSTANDING</label>"  : "<label style=\"font-size: 14px; \" class=\"label label-success\">PASS</label>" ,
                    StudentId = ar.StudentId,
                    WeightMark = (a.Weight / 100) * ar.NewMark,
                    CourseId = a.CourseId,
                    Outstanding = ar.Outstanding
                }).ToListAsync();
           

            return Json(getAllMyStudentAssignments);

        }

        public async Task<IActionResult> GetAllMyStudentsAssignment([FromQuery] Guid courseId, [FromQuery] string studentId)
        {
            var getAllMyStudentAssignments = await (
                from  ar in _context.AssignmentResults
                where ar.StudentId == studentId 
                join a in _context.Assignments
                    on ar.AssignmentId equals a.Id
                join c in _context.Course
                    on a.CourseId equals c.Id
                where a.CourseId == courseId 
                select new
                {
                    Id = ar.Id,
                    AssignmentId = a.Id,
                    AssignmnetResult = ar.Id,
                    AssignmentName = a.Name,
                    AssignmentMark = a.Mark,
                    Weight = a.Weight,
                    NewMark = ar.NewMark,
                    Percentage = ((ar.NewMark / a.Mark) * 100) + " %",
                    StudentId = ar.StudentId,
                    WeightMark = (a.Weight / 100) * ar.NewMark,
                    CourseId = a.CourseId,
                    Outstanding = ar.Outstanding
                }).ToListAsync();
           

            return Json(getAllMyStudentAssignments);
        }
        public async Task<IActionResult> GetMyStudentsAssignmentMark([FromQuery] Guid assignmentResultId)
        {
            var getMyStudentResultForThisAssignment = await (
                from ar in _context.AssignmentResults
                where ar.Id == assignmentResultId
                join a in _context.Assignments
                    on ar.AssignmentId equals a.Id
                select new
                {
                    Id = ar.Id,
                    AssignmnetId = a.Id,
                    CourseId = a.CourseId,
                    AssignmentName = a.Name,
                    AssignmentMark = a.Mark,
                    NewMark = ar.NewMark,
                    OutStanding = ar.Outstanding

                }).SingleOrDefaultAsync();
            return Json(getMyStudentResultForThisAssignment);
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
                    Date = a.ExpireDate.ToString("yyyy MMMM dd"),
                    Name = a.Name, 
                    Weight = a.Weight,
                    CourseId = c.Id,
                    Grade = c.Grade,
                    CourseName = c.CourseName + " - " +c.Grade,
                    Teacher = c.TeacherId

                }).ToListAsync();

            return Json(myAssignments);
        }

       public async Task<IActionResult> UpdateMyAssignment([FromBody] UpdateMyAssignment modal)
        {
            if (ModelState.IsValid)
            {
                var assignmnet = await _context.Assignments.SingleOrDefaultAsync(x => x.Id == modal.Id);
                if (assignmnet != null)
                {
                    assignmnet.CourseId = modal.CourseId;
                    assignmnet.Mark = modal.Mark;
                    assignmnet.Weight = modal.Weight;

                     _context.Assignments.Update(assignmnet);

                     await _context.SaveChangesAsync();

                     return Json(assignmnet);

                }
                return BadRequest("Assignment not found");

            }

            return BadRequest("Modal is not valid");
        }

        public async Task<IActionResult> UpdateCurrentStudentsAssignmentMark([FromBody] UpdateAssignmentPostModal modal)
        {
            if (ModelState.IsValid)
            {
                var assignmentResult =
                    await _context.AssignmentResults.SingleOrDefaultAsync(x =>
                        x.Id == modal
                            .Id);

                if (assignmentResult != null)
                {
                    var assignment =
                            await _context.Assignments.SingleOrDefaultAsync(x => x.Id == assignmentResult.AssignmentId);

                        if (assignment != null)
                        {
                            if (assignment.Mark < modal.NewMark)
                            {
                                return BadRequest("This mark cannot be higher than the grade mark");
                            }
                            else
                            {
                                assignmentResult.NewMark = modal.NewMark;

                                _context.AssignmentResults.Update(assignmentResult);

                                await _context.SaveChangesAsync();

                                return Json(assignmentResult);
                            }
                        }
                        return BadRequest("Assignment  not found");

                    
                }
                return BadRequest("Assignment result not found");

            }

            return BadRequest("Modal not valid");

        }
        public async Task<IActionResult> CreateAssignment([FromBody] CreateAssignmentPostModal modal)
        {
            if (ModelState.IsValid)
            {
                var course = await _context.Course.SingleOrDefaultAsync(x => x.Id == modal.Course);

                if (course != null)
                {
                    var existingAssignment = await _context.Assignments.SingleOrDefaultAsync(x => x.Name == modal.Name && x.Mark == modal.Mark && 
                        x.CourseId == course.Id && x.Weight == modal.Weight && x.ExpireDate == modal.ExpireDate);

                    if (modal.ExpireDate > DateTime.Now)
                    {
                        if (existingAssignment == null)
                        {

                            var newAssignment = new Assignments()
                            {
                                Id = Guid.NewGuid(),
                                Name = modal.Name,
                                Mark = modal.Mark,
                                CourseId = course.Id,
                                Weight = modal.Weight,
                                ExpireDate = modal.ExpireDate

                            };
                        
                            var myStudents = await _context.MyCourses.Where(x => x.CourseId == course.Id && x.Status == true).ToListAsync();
                            if (myStudents.Count > 0)
                            {
                                foreach (var allMyStudents in myStudents)
                                {
                                    var assignmentResults = new AssignmentResults()
                                    {
                                        Id = Guid.NewGuid(),
                                        StudentId = allMyStudents.StudentId,
                                        NewMark = 0,
                                        AssignmentId = newAssignment.Id

                                    };
                                    await _context.AddRangeAsync(assignmentResults);

                                }
                                await _context.Assignments.AddAsync(newAssignment);
                                await _context.SaveChangesAsync();
                                return Json(newAssignment);
                            }
                       
                            return BadRequest("You have no students to give an assignment to");
                       

                        }
                        return BadRequest("There is already an Assignment with the same information");
                    }

                    return BadRequest("Please choose a valid date and time to create an assignment");
                    
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
