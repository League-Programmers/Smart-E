using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using Smart_E.Data;
using Smart_E.Models;
using Smart_E.Models.Teachers;

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
        //public IActionResult TeacherDetails()
        //{
            public async Task<IActionResult> GetTeachers()
            {
                var teachers = await (
                    from u in _db.Users
                    join ur in _db.UserRoles
                        on u.Id equals ur.UserId
                    join r in _db.Roles
                on ur.RoleId equals r.Id
                    where r.Name == "Teacher"
                    select new
                    {
                        Id = u.Id,
                        Name = u.FirstName + " " + u.LastName,
                        Email = u.Email,
                        Role = r.Name

                    }).ToListAsync();

                return Json(teachers);
            }
            //IEnumerable<Teachers> objList = _db.Teachers;
            //return View(objList);
        //}
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


        public async Task<IActionResult> Assign()
        {
            
            var teachers = await(
                    from u in _db.Users
                    join ur in _db.UserRoles
                        on u.Id equals ur.UserId
                    join r in _db.Roles
                on ur.RoleId equals r.Id
                    where r.Name == "Teacher"
                    select new
                    {
                        Id = u.Id,
                        Name = u.FirstName + " " + u.LastName,
                        Email = u.Email,
                        Role = r.Name

                    }).ToListAsync();

            //teachers.Insert(0, new Teacher { Id = 0, Name = "--Select Teacher Name--" });
            //ViewBag.message = teachers;
            //List<Subject> subject = new List<Subject>();
            //subject = (from c in _db.Subjects select c).ToList();
            //subject.Insert(0, new Subject { SubjId = 0, Name = "--Select Subject--" });
            //ViewBag.message = subject;
            return View(teachers);
            // var dbValues = _db.Teachers.ToList();

            // Make Selectlist, which is IEnumerable<SelectListItem>
            //var yourDropdownList = new SelectList(dbValues.Select(item => new SelectListItem
            //{
            //    Text = item.Name,
            //    Value = item.Id
            //}).ToList(), "Value", "Text");

            // Assign the Selectlist to the View Model
            //var viewModel = new Assign()
            //{
            //      Optional: if you want a pre - selected value - remove this for no pre-selected value
            //     Id = dbValues.FirstOrDefault(),
            //      The Dropdownlist values
            //     TeacherDropdownList = (IEnumerable<Teacher>)yourDropdownList
            // };

            //  return View with View Model
            // return View();


        }
        }
}
