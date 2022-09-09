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
        public async Task<IActionResult> GetAllUserRoles()
        {
            var roles = await (
                from r in _context.Roles
                select new
                {
                    Id = r.Id,
                    Name = r.Name

                }).ToListAsync();

            return Json(roles);
        }

        public async Task<IActionResult> GetUser([FromQuery]string id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
               

            return Json(user);
        }

        public async Task<IActionResult> DeleteUser([FromQuery]string id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return Json(user);
            }

            return BadRequest("User Not Found");
        }


    }
}
