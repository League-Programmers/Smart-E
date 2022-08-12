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

        public IActionResult ViewAttendance()
        {          
            return View();
        }

        public IActionResult CreateSubject()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSubject(Subject obj)
        {
            if (ModelState.IsValid)
            {
                _db.Subjects.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("HODDashboard");
            }
            return View(obj);
        }

    }
}
