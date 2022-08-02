using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;

namespace Smart_E.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await (
                from c in _db.Student
                select new
                {
                    Name = c.Name,
                    Email = c.Email,
                    Grade = c.Grade,
                    Subjects = c.Subjects,
                    Progress = c.Progress,
                    Active = c.Active

                }).ToListAsync();

            return Json(students);
        }
    }
}
