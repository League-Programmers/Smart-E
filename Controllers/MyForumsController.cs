using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;

namespace Smart_E.Controllers
{
    public class MyForumsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MyForumsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> MyForums()
        {
            var user = await _userManager.GetUserAsync(User);
            var myForums = await (
                from t in _context.TeacherForums
                join u in _context.Users
                    on t.ParentId equals u.Id
                    where t.TeacherId == user.Id
                select new
                {
                    Id = t.Id,
                    Message = t.Message,
                    TeacherId = t.TeacherId,
                    ParentId = u.Id,
                    ParentName = u.FirstName + " "+ u.LastName,
                    Date = t.Date,
                }).ToListAsync();

            return View(myForums);
        }
    }
}
