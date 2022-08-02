using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;

namespace Smart_E.Controllers
{
    public class ParentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ParentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllParents()
        {
            var parents = await (
                from c in _db.Parent
                select new
                {
                    Name = c.Name,
                    Email = c.Email,
                    StudentName = c.StudentName,
                    Subjects = c.Subjects,
                    TeacherEmail = c.TeacherEmail,
                    Progress = c.Progress,
                    Active = c.Active

                }).ToListAsync();

            return Json(parents);
        }
    }
}
