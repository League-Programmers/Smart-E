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
            var teachers = await (
                from c in _context.Users
                select new
                {
                    Name = c.FirstName + " "+ c.LastName,
                    Email = c.Email


                }).ToListAsync();

            return Json(teachers);
        }
    }
}
