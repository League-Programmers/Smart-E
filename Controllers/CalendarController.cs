using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;

namespace Smart_E.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalendarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Calendar()
        {
            return View();
        }

        public async Task<JsonResult> GetEvents()
        {
            var getALLEvents = await(
                from c in _context.Calendars
                select new
                {
                    c.Id,
                    c.Description,
                    c.End,
                    c.Start

                }).ToListAsync();

            return Json(getALLEvents);

            //using (ApplicationDbContext dc = new ApplicationDbContext())
            //{
            //    var events = dc.Calendars.ToList();
            //    return Json(new { Data = events, JsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings()});
            //}
        }

        [HttpPost]
        public JsonResult SaveEvent(Calendar e)
        {
            var status = false;
            //using (ApplicationDbContext  = new ApplicationDbContext())
            //{
            
            if (e.Id != null)
                {
                    //Update the event
                    var v = _context.Calendars.Where(a => a.Id == e.Id).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                    v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    _context.Calendars.Add(e);
                }

                _context.SaveChanges();
                status = true;

            //}
            return Json(new { Data = new { status = status } });
            //return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(string eventID)
        {
            var status = false;
            using (ApplicationDbContext dc = new ApplicationDbContext())
            {             
                var v = dc.Calendars.Where(a => a.Id == new Guid(eventID)).FirstOrDefault();        
                if (v != null)
                {
                    dc.Calendars.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return Json(new { Data = new { status = status } });
        }
    }
}
