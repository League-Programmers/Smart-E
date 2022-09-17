using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models.Events;
using SharpYaml.Serialization;
using Smart_E.Models;
using Microsoft.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;

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
        [HttpGet]
        public IActionResult UploadAttachment()
        {
            ViewBag.Action = "Upload";
            ViewBag.Chapter = _context.Chapter.Select(t => t).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult UploadAttachment(EventBooking model)
        {
            if (model.FileContent != null)
            {
                //write file to a physical path
                var uniqueFileName = SpClass.CreateUniqueFileExtension(model.FileContent.FileName);
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "attachment");
                var filePath = Path.Combine(uploads, uniqueFileName);

                model.FileContent.CopyTo(new FileStream(filePath, FileMode.Create));

                ViewBag.Chapter = _context.Chapter.Select(t => t).ToList();
                //save the attachment to the database
                EventBooking document = new EventBooking();
                document.FileName = uniqueFileName;
                document.BookingId = model.BookingId;


                document.FileContent = SpClass.GetByteArrayFromImage(model.FileContent);

                _context.EventBooking.Add(document);

                _context.SaveChanges();

            }

            return RedirectToAction("Bookings", "EventBooking", new { id = model.BookingId });
        }

        [HttpGet]
        public FileResult GetFileResultDemo(string filename)
        {
            string path = "/attachment/" + filename;
            string contentType = SpClass.GetContenttype(filename);
            return File(path, contentType);
        }

        [HttpGet]
        public FileContentResult GetFileContentResultDemo(string filename)
        {
            string path = "wwwroot/attachment/" + filename;
            byte[] fileContent = System.IO.File.ReadAllBytes(path);
            string contentType = SpClass.GetContenttype(filename);
            return new FileContentResult(fileContent, contentType);
        }

        [HttpGet]
        public FileStreamResult GetFileStreamResultDemo(string filename) //download file
        {
            string path = "wwwroot/attachment/" + filename;
            var stream = new MemoryStream(System.IO.File.ReadAllBytes(path));
            string contentType = SpClass.GetContenttype(filename);
            return new FileStreamResult(stream, new MediaTypeHeaderValue(contentType))
            {
                FileDownloadName = filename
            };
        }

        [HttpGet]
        public VirtualFileResult GetVirtualFileResultDemo(string filename)
        {
            string path = "attachment/" + filename;
            string contentType = SpClass.GetContenttype(filename);
            return new VirtualFileResult(path, contentType);
        }

        [HttpGet]
        public PhysicalFileResult GetPhysicalFileResultDemo(string filename)
        {
            string path = "/wwwroot/attachment/" + filename;
            string contentType = SpClass.GetContenttype(filename);
            return new PhysicalFileResult(_hostingEnvironment.ContentRootPath
                + path, contentType);
        }

        [HttpGet]
        public ActionResult GetAttachment(int ID)
        {
            byte[] fileContent;
            string fileName = string.Empty;
            EventBooking document = new EventBooking();
            document = _context.EventBooking.Select(m => m).Where(m => m.BookingId == ID).FirstOrDefault();

            string contentType = SpClass.GetContenttype(document.FileName);
            fileContent = (byte[])document.FileContent;
            return new FileContentResult(fileContent, contentType);
        }

        [HttpGet]
        public IActionResult DeleteAttachment(int id)
        {
            ViewBag.Action = "Delete";
            ViewBag.chapter = _context.Chapter.OrderBy(c => c.CourseId).ToList();
            var file = _context.EventBooking.Include(c => c.FileName).Include(c => c.FileContent)
                .FirstOrDefault(f => f.BookingId == id);
            return View(file);
        }

        [HttpPost]
        public IActionResult DeleteAttachment(EventBooking document)
        {
            ViewBag.Action = "Delete";
            ViewBag.chapter = _context.Chapter.OrderBy(c => c.CourseId).ToList();
            _context.EventBooking.Remove(document);
            _context.SaveChanges();
            return RedirectToAction("Bookings", "EventBooking");
        }

    }
}
