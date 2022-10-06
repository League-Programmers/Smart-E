using Microsoft.AspNetCore.Mvc;
using Smart_E.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;

namespace Smart_E.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Student()
        {
            return View();
        }
        public async Task<IActionResult> Parent()
        {
            var parent = await _userManager.GetUserAsync(User);
            ViewBag.TotalInvites = _context.Invites.Where(c => c.InviteTo == parent.Id && c.Status == false).Count();
            ViewBag.TotalChildren = _context.Invites.Where(c => c.InviteTo == parent.Id && c.Status == true).Count();
            ViewBag.TotalChats = _context.ChatRoom.Count();
            return View();
        }
        public IActionResult Admin()
        {
            IEnumerable<ApplicationUser> userList = _context.Users;
            return View(userList);
        }
        public IActionResult HOD()
        {
            return View();
        }

       public IActionResult Teacher()
        {
            ViewBag.TotalParents = _context.UserRoles.Where(c => c.RoleId == "8f18ff88-e58e-4ee6-8ee0-82072a1e6d76").Count();
            ViewBag.TotalLearners = _context.UserRoles.Where(c => c.RoleId == "8d709b3e-7d72-4451-8d3d-340e527d1c16").Count();
            ViewBag.TotalSubjects = _context.Course.Count();
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}