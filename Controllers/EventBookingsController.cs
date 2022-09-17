using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models.Events;

namespace Smart_E.Controllers
{
    public class EventBookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventBookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventBookings
        public async Task<IActionResult> Index()
        {
              return View(await _context.EventBooking.ToListAsync());
        }

        // GET: EventBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EventBooking == null)
            {
                return NotFound();
            }

            var eventBooking = await _context.EventBooking
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (eventBooking == null)
            {
                return NotFound();
            }

            return View(eventBooking);
        }

        // GET: EventBookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,CreatedBy,EventTypeId,DateCreated,FileName,FileContent")] EventBooking eventBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventBooking);
        }

        // GET: EventBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EventBooking == null)
            {
                return NotFound();
            }

            var eventBooking = await _context.EventBooking.FindAsync(id);
            if (eventBooking == null)
            {
                return NotFound();
            }
            return View(eventBooking);
        }

        // POST: EventBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,CreatedBy,EventTypeId,DateCreated,FileName,FileContent")] EventBooking eventBooking)
        {
            if (id != eventBooking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventBookingExists(eventBooking.BookingId))
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
            return View(eventBooking);
        }

        // GET: EventBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EventBooking == null)
            {
                return NotFound();
            }

            var eventBooking = await _context.EventBooking
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (eventBooking == null)
            {
                return NotFound();
            }

            return View(eventBooking);
        }

        // POST: EventBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EventBooking == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EventBooking'  is null.");
            }
            var eventBooking = await _context.EventBooking.FindAsync(id);
            if (eventBooking != null)
            {
                _context.EventBooking.Remove(eventBooking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventBookingExists(int id)
        {
          return _context.EventBooking.Any(e => e.BookingId == id);
        }
    }
}
