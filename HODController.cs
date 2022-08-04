using Microsoft.AspNetCore.Mvc;
using Smart_E.Data;

namespace Smart_E.Controllers
{
    public class HODController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HODController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult HODDashboard()
        {
            return View();
        }

        public IActionResult TeacherDetails()
        {
            IEnumerable<Teachers> objList = _db.Teachers;
            return View(objList);
        }

    }
}
