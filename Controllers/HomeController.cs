using Microsoft.AspNetCore.Mvc;
using Smart_E.Models;
using System.Diagnostics;
using Smart_E.Data;

namespace Smart_E.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Student()
        {
            return View();
        }
        public IActionResult Parent()
        {
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