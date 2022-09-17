using Microsoft.AspNetCore.Mvc;
using Smart_E.Models;
using System.Diagnostics;
using Smart_E.Data;

namespace Smart_E.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }
        public IActionResult Dashboard()
        {
            ViewBag.TotalParents = _context.UserRoles.Where(c => c.RoleId == "807c239e-8fab-44e5-8f28-e5d495916398").Count();
            ViewBag.TotalLearners = _context.UserRoles.Where(c => c.RoleId == "9896e59a-75ae-4b68-9095-c273387205e2").Count();
            ViewBag.TotalSubjects = _context.Course.Count();
            return View();
        }
        public IActionResult Index()
        {
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