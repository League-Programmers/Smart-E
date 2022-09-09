using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;

namespace Smart_E.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Users()
        {
            return View();
        }
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await (
                from c in _context.Users
                join ur in _context.UserRoles
                    on c.Id equals ur.UserId
                    join r in _context.Roles
                    on ur.RoleId equals r.Id
                select new
                {
                    Id = c.Id,
                    Name = c.FirstName + " "+ c.LastName,
                    Email = c.Email,
                    Status = c.Status,
                    Role = r.Name

                }).ToListAsync();

            return Json(users);
        }

        public async Task<IActionResult> GetUser([FromQuery]string id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
               

            return Json(user);
        }
    }
}
