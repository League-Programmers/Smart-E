using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models.Teachers;

namespace Smart_E.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TeachersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Teachers()
        {
            return View();
        }
        public IActionResult Index()
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
<<<<<<< HEAD
                    TeacherName = c.Name,
                    Email = c.Email
=======
                    Id = u.Id,
                    Name = u.FirstName + " "+ u.LastName,
                    Email = u.Email,
                    Role = r.Name
>>>>>>> main

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
<<<<<<< HEAD
                var existingTeacher = await _context.TeachersReport.SingleOrDefaultAsync(x => x.Name == model.Name && x.Email == model.Email);
=======
                /*var existingTeacher = await _context.Teachers.SingleOrDefaultAsync(x => x.TeacherName == model.TeacherName && x.Email == model.Email);
>>>>>>> main

                if (existingTeacher == null)
                {
                    var teacher = new Teachers()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
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
