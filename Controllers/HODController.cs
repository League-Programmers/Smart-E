using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using Smart_E.Data;
using Smart_E.Models;

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
            IEnumerable<Teacher> objList = _db.Teachers;
            return View(objList);
        }
        public IActionResult Grades()
        {
            IEnumerable<Grade> objList = _db.grades;
            return View(objList);
        }
        public IActionResult HODReports()
        {
            return View();
        }
        public IActionResult ViewSubjects()
        {
            IEnumerable<Subject> objList = _db.Subjects;
            return View(objList);
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


        public IActionResult Assign()
        {
            ////List<Teacher> teacher = new List<Teacher>();
            ////teacher = (from c in _db.Teachers select c).ToList();
            ////teacher.Insert(0, new Teacher { Id = 0, Name = "--Select Teacher Name--" });
            ////ViewBag.message = teacher;
            ////List<Subject> subject = new List<Subject>();
            ////subject = (from c in _db.Subjects select c).ToList();
            ////subject.Insert(0, new Subject { SubjId = 0, Name = "--Select Subject--" });
            ////ViewBag.message = subject;
            ////return View(teacher);
            //var dbValues = _db.Teachers.ToList();

            //// Make Selectlist, which is IEnumerable<SelectListItem>
            ////var yourDropdownList = new SelectList(dbValues.Select(item => new SelectListItem
            ////{
            ////    Text = item.Name,
            ////    Value = item.Id
            ////}).ToList(), "Value", "Text");

            //// Assign the Selectlist to the View Model   
            //var viewModel = new Assign()
            //{
            //    // Optional: if you want a pre-selected value - remove this for no pre-selected value
            //    //Id = dbValues.FirstOrDefault(),
            //    // The Dropdownlist values
            //    //TeacherDropdownList = (IEnumerable<Teacher>)yourDropdownList
            //};

            //// return View with View Model
            return View();


        }
        }
}
