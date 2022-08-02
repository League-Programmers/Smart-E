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
                from c in _context.Teachers
                select new
                {
                    TeacherName = c.Name,
                    Email = c.Email

                }).ToListAsync();

            return Json(teachers);
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
                var existingTeacher = await _context.TeachersReport.SingleOrDefaultAsync(x => x.Name == model.Name && x.Email == model.Email);

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

                return BadRequest("This Teacher already Exists");

            }
            return BadRequest("Model is not valid");
        }
      


    }
}
