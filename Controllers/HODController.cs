using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllHODs()
        {
            var HODs = await (
                from c in _db.HOD
                select new
                {
                    Name = c.Name,
                    Email = c.Email,
                    Department = c.Department,
                    Targets = c.Targets,
                    Active = c.Active
                }).ToListAsync();

            return Json(HODs);
        }
    }
}
