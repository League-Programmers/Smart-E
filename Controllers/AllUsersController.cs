using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;

namespace Smart_E.Controllers
{
    public class AllUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AllUsersController(ApplicationDbContext context ,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager
        )
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
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
                    TeacherName = u.FirstName + " " + u.LastName,
                    Email = u.Email,
                }).ToListAsync();
            return Json(teachers);


        }

        public IActionResult Teachers()
        {
            return View();
        }
       
        public IActionResult Students()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await (
                from u in _context.Users
                join ur in _context.UserRoles
                    on u.Id equals ur.UserId
                join r in _context.Roles
                    on ur.RoleId equals r.Id
                where r.Name == "Student"
                select new
                {
                    Id = u.Id,
                    StudentName = u.FirstName + " " + u.LastName,
                    Email = u.Email,
                    Role = r.Name

                }).ToListAsync();
            return Json(students);
        }
        public IActionResult Parents()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParents()
        {
            var parents = await (
                from u in _context.Users
                join ur in _context.UserRoles
                    on u.Id equals ur.UserId
                join r in _context.Roles
                    on ur.RoleId equals r.Id
                where r.Name == "Parent"
                select new
                {
                    Id = u.Id,
                    ParentName = u.FirstName + " " + u.LastName,
                    Email = u.Email,

                }).ToListAsync();
            return Json(parents);

        }
    }
}
