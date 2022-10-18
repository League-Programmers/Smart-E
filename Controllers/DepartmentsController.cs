using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;
using Smart_E.Models.Departments;

namespace Smart_E.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> AllDepartments()
        {
            //List<Department> dept = _context.Department.ToList();
            //DepartmentViewModel viewModel = new DepartmentViewModel();
            //List<DepartmentViewModel> viewModelsList = dept.Select(x => new DepartmentViewModel
            //{
            //    DeptName = x.DeptName,
            //    HOD = x.HODs.FirstName + " " + x.HODs.LastName,
            //    Subject = x.Course.CourseName
            //}).ToList();
            //return View(viewModel);
            //return View(await _context.Department.ToListAsync());
            var dept = await (from d in _context.Department
                              join c in _context.Course
                              on d.CourseId equals c.Id
                              join h in _context.Users
                              on d.HODId equals h.Id
                              select new
                              {
                                  id = d.Id,
                                  deptName = d.DeptName,
                                  hodId = h.Id,
                                  hod = h.FirstName + " " + h.LastName,
                                  subjectId = c.Id,
                                  subject = c.CourseName                                
                              }).OrderBy(x => x.hod).ToListAsync();
            return Json(dept);
        }
        public IActionResult Departments()
        {
            return View();        
        }

        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentPostModal modal)
        {
            if (ModelState.IsValid)
            {
                var department = await _context.Department.SingleOrDefaultAsync(x => x.DeptName == modal.DepartName && x.HODId == modal.HodName);
                if (department == null)
                {
                    var depart = new Department()
                    {
                        Id = Guid.NewGuid(),
                        DeptName = modal.DepartName,
                        HODId = modal.HodName
                    };
                    await _context.Department.AddAsync(depart);
                    await _context.SaveChangesAsync();

                    return Json(depart);
                }

                return BadRequest("Department already exists with this HOD user");
            }

            return BadRequest("Modal not valid");
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = await _context.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DeptName,HODId,CourseId")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Departments");
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Department == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Department'  is null.");
            }
            var department = await _context.Department.FindAsync(id);
            if (department != null)
            {
                _context.Department.Remove(department);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(Guid id)
        {
          return _context.Department.Any(e => e.Id == id);
        }

        //public async Task<IActionResult> GetSubjectsList()
        //{

        //    var subjects = await _context.Course.ToListAsync();
        //    List<DepartmentPostModal> subjectViewModel = new List<DepartmentPostModal>();
        //    foreach (Course subject in subjects)
        //    {
        //        var thisViewModel = new DepartmentPostModal();
        //        thisViewModel.CourseId = subject.Id;
        //        //thisViewModel.CourseList = subject.CourseName;
        //        subjectViewModel.Add(thisViewModel);
        //    }
        //    return View(subjectViewModel);

        //}
        public async Task<IActionResult> GetHODs()
        {

            var hod = await (
                from u in _context.Users
                join ur in _context.UserRoles
                on u.Id equals ur.UserId
                join r in _context.Roles
                on ur.RoleId equals r.Id
                where r.Name == "HOD"
                select new
                {
                    Id = u.Id,
                    Name = u.FirstName + " " + u.LastName,

                }).ToListAsync();

            return Json(hod);

        }
        public async Task<IActionResult> GetSubjects()
        {

            var subjects = await (
                from c in _context.Course
                select new
                {
                    Id = c.Id,
                    Name = c.CourseName,

                }).ToListAsync();

            return Json(subjects);

        }
    }
}
