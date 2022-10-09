using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
        public IActionResult MyForums()
        {
            return View();
        }
        public async Task<IActionResult> AllMyForums()
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
                }).OrderBy(x=>x.Date).ToListAsync();

            return Json(myForums);
        }

        public async Task<IActionResult> GetMyForum([FromQuery] Guid id )
        {
            var forum = await (
                from f in _context.TeacherForums
                join u in _context.Users
                    on f.ParentId equals u.Id
                    where f.Id == id
                select new
                {
                    Id = f.Id,
                    Message = f.Message,
                    ParentName = u.FirstName + " " + u.LastName

                }).SingleOrDefaultAsync();

            return Json(forum);

        }
    }
}
