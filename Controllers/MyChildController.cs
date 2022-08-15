using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models.MyChild;

namespace Smart_E.Controllers
{
    public class MyChildController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyChildController(ApplicationDbContext context)
        {
            _context = context;
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

        public IActionResult MyChild()
        {
            return View();
        }

        public async Task<IActionResult>GetChildren()
        {
            var children = await (
                from u in _context.Users
                join ur in _context.UserRoles
                    on u.Id equals ur.UserId
                join r in _context.Roles
                    on ur.RoleId equals r.Id
                where r.Name == "Student"
                select new
                {
                    Id = u.Id,
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
