﻿using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;
using Smart_E.Models.Teachers;

namespace Smart_E.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public TeachersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Teachers()
        {
            return View();
        }
        public async Task<IActionResult> GetLearners()
        {
            var user = await _userManager.GetUserAsync(User);
            var Learners = await (
                from myC in _context.MyCourses
                join c in _context.Course
                on myC.CourseId equals c.Id
                join u in _context.Users
                on myC.StudentId equals u.Id
                where c.TeacherId == user.Id && myC.Status == true
                select new
                {
                    Id = u.Id,
                    Name = u.FirstName + " " + u.LastName,
                    Subject = c.CourseName + " " + c.Grade,


                }).ToListAsync();
            
          
            return Json(Learners);

        }
        public IActionResult GradeAssessment()
        {
            return View();
        }

        public IActionResult createReport()
        {
            return View();
        }

        public async Task<IActionResult> GetTeachers()
        {
            var teachers = await (
                from u in _context.Users
                join ur in _context.UserRoles
                    on u.Id equals ur.UserId
                    join r in _context.Roles
                    on ur.RoleId equals r.Id
                where r.Name == "Teacher"
                select new
                {
                    Id = u.Id,
                    Name = u.FirstName + " "+ u.LastName,
                    Email = u.Email,
                    Role = r.Name

                }).ToListAsync();

            return Json(teachers);
        }
        public async Task<IActionResult> GetTeacher([FromQuery] string id)
        {
            var teacher = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            return Json(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherPostModel model)
        {
            /* if (!(await _userManager.IsInRoleAsync(user, "Administrator")))
                            {
                                throw new Exception($"You are not allowed to add teacher, because you don't have the Administrator role assigned to you.");
                            }*/

            if (ModelState.IsValid)
            {
                /*var existingTeacher = await _context.Teachers.SingleOrDefaultAsync(x => x.TeacherName == model.TeacherName && x.Email == model.Email);

                if (existingTeacher == null)
                {
                    var teacher = new Teachers()
                    {
                        Id = Guid.NewGuid(),
                        TeacherName = model.TeacherName,
                        Email = model.Email
                    };
                    await _context.Teachers.AddAsync(teacher);

                    await _context.SaveChangesAsync();

                    return Json(teacher);
                }

                return BadRequest("This Teacher already Exists");*/

            }
            return BadRequest("Model is not valid");
        }
      


    }
}
