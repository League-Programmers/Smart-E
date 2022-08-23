using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;

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
            var user = await (
                from c in _context.Users
                select new
                {
                    Name = c.FirstName + " "+ c.LastName,
                    Email = c.Email,
                    Role = c.Role,
                    Status = c.Status
                }).ToListAsync();
            
            return Json(user);
        }
    }
}
