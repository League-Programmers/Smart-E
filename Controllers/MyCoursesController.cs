using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart_E.Models;

namespace Smart_E.Controllers
{
    public class MyCoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public MyCoursesController( ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult MyCourses()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> DeleteCourseInvite([FromQuery] Guid id)
        {
            var myInvite = await _context.MyCourses.SingleOrDefaultAsync(x => x.Id == id);

            if (myInvite != null)
            {
                _context.MyCourses.Remove(myInvite);
                await _context.SaveChangesAsync();

                return Json(myInvite);

            }

            return BadRequest("Course Invite not found");
        }
        [HttpPost]

        public async Task<IActionResult> UpdateStudentCourseInvite([FromQuery] Guid id)
        {
            var invite = await _context.MyCourses.SingleOrDefaultAsync(x => x.Id == id);

            if (invite != null)
            {
                invite.Status = true;
                _context.MyCourses.Update(invite);


                await _context.SaveChangesAsync();

                return Json(invite);
            }

            return BadRequest("Invite not found");

        }
        [HttpGet]
        public async Task<IActionResult> GetAllMyCourses()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var courses = await (
                from c in _context.Course
                join mc in _context.MyCourses
                    on c.Id equals mc.CourseId
                join u in _context.Users
                    on mc.StudentId equals u.Id
                where c.TeacherId == user.Id && mc.Status == false
                select new
                {
                    Id = mc.Id,
                    CourseId = c.Id,
                    CourseName = c.CourseName,
                    UserId = u.Id,
                    Email = u.Email,
                    StudentName = u.FirstName + " " +u.LastName 
                }).ToListAsync();
           
            return Json(courses);
        }

    }
}
