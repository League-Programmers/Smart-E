﻿using DocumentFormat.OpenXml.Office2010.Word;
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
        [HttpPost]
        public async Task<IActionResult> MessageTeacherFromParent([FromQuery] string teacherId, [FromBody] SendMessagePostModal modal)
        {
            if (ModelState.IsValid)
            {
                var currentParent = await _userManager.GetUserAsync(User);
                var teacher = await _context.Users.SingleOrDefaultAsync(x => x.Id == teacherId);

                if (teacher != null)
                {
                    var date = DateTime.Now;
                    var forum = new TeacherForums()
                    {
                        Id = Guid.NewGuid(),
                        ParentId = currentParent.Id,
                        TeacherId = teacher.Id,
                        Message = modal.Message,
                        Date = date
                    };

                    await _context.TeacherForums.AddAsync(forum);

                    await _context.SaveChangesAsync();

                    return Json(forum);

                }

                return BadRequest("Teacher not found");
            }

            return BadRequest("Modal not valid");

            
        }

        public async Task<IActionResult> MyChildsSubjectProgress([FromQuery] string studentId, [FromQuery] Guid courseId)
        {

            float total = 0;
            var student = await _context.Users.SingleOrDefaultAsync(x => x.Id == studentId);

            if (student != null)
            {
                var course = await _context.Course.SingleOrDefaultAsync(x => x.Id == courseId);

                if (course != null)
                {
                    var myCourse =
                        await _context.MyCourses.SingleOrDefaultAsync(x =>
                            x.CourseId == courseId && x.StudentId == studentId);

                    if (myCourse != null)
                    {
                        var teacher = await _context.Users.SingleOrDefaultAsync(x => x.Id == course.TeacherId);
                        if (teacher != null)
                        {
                            var myChildsAssignments =
                                await _context.Assignments.Where(x => x.CourseId == courseId).ToListAsync();

                            if (myChildsAssignments.Count > 0)
                            { 
                                float results = 0;

                                foreach (var myChildsAssignmentss in myChildsAssignments)
                                {
                                var assignments = await _context.AssignmentResults
                                    .Where(x=> x.StudentId == studentId).ToListAsync();


                                foreach (var result in assignments)
                                {
                                    float weightMark = ((result.NewMark / myChildsAssignmentss.Mark) * myChildsAssignmentss.Weight );

                                    total = weightMark + total;
                                    return View(new MyStudentsProgressViewModel()
                                    {
                                        Id = student.Id,
                                        Name = student.FirstName + " " + student.LastName,
                                        StudentEmail = student.Email,
                                        CourseId = course.Id,
                                        Grade = course.Grade,
                                        CourseName = course.CourseName,
                                        TeacherId = course.TeacherId,
                                        TeacherName = teacher.FirstName + " " + teacher.LastName,
                                        TeacherEmail = teacher.Email,
                                        NumberOfClasses = course.NumberOfClasses,
                                        NumberOfClassesAttended = myCourse.NumberOfClassesAttended,
                                        AttendancePercentage = ((myCourse.NumberOfClassesAttended / course.NumberOfClasses) * 100) + " %",
                                        NumberOfClassesNotAttended = course.NumberOfClasses - myCourse.NumberOfClassesAttended,
                                        YearMark = total 
                                    });
                                }

                                }
                            }

                           
                            return View(new MyStudentsProgressViewModel()
                            {
                                Id = student.Id,
                                Name = student.FirstName + " " + student.LastName,
                                StudentEmail = student.Email,
                                CourseId = course.Id,
                                Grade = course.Grade,
                                CourseName = course.CourseName,
                                TeacherId = course.TeacherId,
                                TeacherName = teacher.FirstName + " " + teacher.LastName,
                                TeacherEmail = teacher.Email,
                                NumberOfClasses = course.NumberOfClasses,
                                NumberOfClassesAttended = myCourse.NumberOfClassesAttended,
                                AttendancePercentage = ((myCourse.NumberOfClassesAttended / course.NumberOfClasses) * 100) + " %",
                                NumberOfClassesNotAttended = course.NumberOfClasses - myCourse.NumberOfClassesAttended,
                                YearMark = 0
                                
                            });
                        }

                    }

                    return BadRequest("Student for this course not found");


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
                    Grade = c.Grade,
                    CourseId = c.Id,
                }).ToListAsync();

            return Json(student);

        }

        public IActionResult MyChild()
        {
            return View();
        }

        public async Task<IActionResult>GetChildren([FromQuery] string id)
        {
            var children = await (
                from i in _context.Invites
                join u in _context.Users
                    on i.InviteFrom equals u.Id
                where i.Status == true && i.InviteTo ==id
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
