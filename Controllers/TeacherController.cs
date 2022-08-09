using System.Net;
using System.Net.Mail;
using System.Threading.Tasks.Dataflow;
using System.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;
using Smart_E.Models.Teachers;
using Smart_E.Services.Email;

namespace Smart_E.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public TeachersController(ApplicationDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
        public IActionResult Teachers()
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
                where r.Name =="Teacher"
                select new
                {
                    Id = u.Id,
                    Name = u.FirstName + " " + u.LastName,
                    Email = u.Email

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

            if (ModelState.IsValid)
            {
                var existingTeacher = await _context.Teachers.SingleOrDefaultAsync(x => x.Name == model.TeacherName && x.Email == model.Email);

                if (existingTeacher == null)
                {
                    var teacher = new Teachers()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.TeacherName,
                        Email = model.Email
                    };
                    await _context.Teachers.AddAsync(teacher);

                    await _context.SaveChangesAsync();

                    return Json(teacher);
                }

                return BadRequest("This Teacher already Exists");

            }
            return BadRequest("Model is not valid");
        }
      


    }
}
