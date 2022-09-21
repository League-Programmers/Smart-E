using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;

namespace Smart_E.Controllers
{
    public class BookingDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingDetailsController(ApplicationDbContext context)
        {
            _context = context;

        }
        //public async Task<IActionResult> Bookings()
        //{
        //    return View(await _context.BookingDetails.ToListAsync());
        //}
        public async Task<IActionResult> AllBookings()
        {
            var bookings = await (from b in _context.BookingDetails
                                  join eb in _context.EventBooking
                                  on b.BookingNo equals eb.BookingId
                                  select new
                                  {
                                      BookingNo = eb.BookingId,
                                      BookingDate = b.BookingDate,
                                      CreatedBy = eb.CreatedBy,
                                      DateCreated = eb.DateCreated,
                                      BookingApproval = eb.Status,
                                      BookingApprovalDate = DateTime.Now,                                   
                                  }).ToListAsync();
            return View(bookings);
        }
        public IActionResult Approve(int id)
        {
            var booking = _context.BookingDetails.FirstOrDefault(b => b.BookingId == id);
            if (booking == null)
                return NotFound();
            return View(booking);
        }
        [HttpPost]
        public async Task<IActionResult> Approve()
        {
            var booking = await (from b in _context.BookingDetails
                                 select new
                                 {
                                     BookingId = b.BookingId,
                                     BookingNo = b.BookingNo,
                                     BookingDate = b.BookingDate,
                                     CreatedBy = b.CreatedBy,
                                     DateCreated = b.DateCreated,
                                     BookingApproavalDate = DateTime.Now,
                                     BookingCompletedFlag = true
                                 }).ToListAsync();
            _context.Entry(booking).State = EntityState.Modified;
            _context.SaveChanges();
            return View(booking);
        }
        public IActionResult Reject(int id)
        {
            var booking = _context.BookingDetails.FirstOrDefault(b => b.BookingId == id);
            if (booking == null)
                return NotFound();
            return View(booking);
        }
        public async Task<IActionResult> Reject()
        {
            var booking = await (from b in _context.BookingDetails
                                 join eb in _context.EventBooking
                                 on b.BookingId equals eb.BookingId
                                 select new
                                 {
                                     BookingNo = eb.BookingId,
                                     BookingDate = b.BookingDate,
                                     CreatedBy = eb.CreatedBy,
                                     DateCreated = eb.DateCreated,
                                     BookingApproavalDate = DateTime.Now,
                                     BookingCompletedFlag = true
                                 }).ToListAsync();
            _context.Entry(booking).State = EntityState.Modified;
            _context.SaveChanges();
            return View(booking);
        }
    }
}
