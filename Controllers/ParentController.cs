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
                from u in _db.Users
                join ur in _db.UserRoles
                on u.Id equals ur.UserId
                join r in _db.Roles
                on ur.RoleId equals r.Id
                where r.Name == "Parent"
                select new
                {
                    Name = u.FirstName + " " + u.LastName,
                    Email = u.Email,
                    /*StudentName = c.StudentName,
                    Subjects = c.Subjects,
                    TeacherEmail = c.TeacherEmail,
                    Progress = c.Progress,
                    Active = c.Active*/

                }).ToListAsync();

            return Json(parents);
        }
    }
}
