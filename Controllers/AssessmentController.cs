using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;

namespace Smart_E.Controllers
{
    public class AssessmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssessmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assessment
        public async Task<IActionResult> Index()
        {
              return _context.Assessment != null ? 
                          View(await _context.Assessment.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Assessment'  is null.");
        }

        // GET: Assessment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assessment == null)
            {
                return NotFound();
            }

            var assessmentModel = await _context.Assessment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assessmentModel == null)
            {
                return NotFound();
            }

            return View(assessmentModel);
        }

        // GET: Assessment/Create
        public async Task<IActionResult> Create(int id = 0)
        {
            if (id == 0)
                return View(new AssessmentModel());
            else
            {
                var assessmentModel = await _context.Assessment.FindAsync(id);
                if (assessmentModel == null)
                {
                    return NotFound();
                }
                return View(assessmentModel);
            }
        }

        // POST: Assessment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Id,AssessmentName,DateStarted,DateSubmitted,Status")] AssessmentModel assessmentModel)
        {
            if (ModelState.IsValid)
            {
                if(id == 0)
                {
                    _context.Add(assessmentModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllAssessments", _context.Assessment.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", assessmentModel) });
        }

        // GET: Assessment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assessment == null)
            {
                return NotFound();
            }

            var assessmentModel = await _context.Assessment.FindAsync(id);
            if (assessmentModel == null)
            {
                return NotFound();
            }
            return View(assessmentModel);
        }

        // POST: Assessment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssessmentName,DateStarted,DateSubmitted,Status")] AssessmentModel assessmentModel)
        {
            if (id != assessmentModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assessmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssessmentModelExists(assessmentModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(assessmentModel);
        }

        // GET: Assessment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assessment == null)
            {
                return NotFound();
            }

            var assessmentModel = await _context.Assessment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assessmentModel == null)
            {
                return NotFound();
            }

            return View(assessmentModel);
        }
        public async Task<IActionResult> ViewReport()
        {
            return _context.Assessment != null ?
                        View(await _context.Assessment.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Assessment'  is null.");
        }
        // POST: Assessment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assessment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Assessment'  is null.");
            }
            var assessmentModel = await _context.Assessment.FindAsync(id);
            if (assessmentModel != null)
            {
                _context.Assessment.Remove(assessmentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssessmentModelExists(int id)
        {
          return (_context.Assessment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
