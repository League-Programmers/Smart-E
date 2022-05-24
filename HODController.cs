using Microsoft.AspNetCore.Mvc;
using Smart_E.Data;

namespace Smart_E.Controllers
{
    public class HODController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HODController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult HOD()
        {
            return View();
        }
        
        public IActionResult GetStudentsReport()
        {
            IEnumerable<Student> objList = _context.Students; 
            return View(objList);
        }


    }
}
