using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;
using Smart_E.Models.Courses;

namespace Smart_E.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Courses()
        {
            var courses = _context.Course
                        .OrderBy(c => c.CourseName).ToList();
            return View(courses);
           
        }

        public IActionResult Course(Guid id)
        {
             ChapterViewModel chapterViewModel = new ChapterViewModel();
             chapterViewModel.chapters = _context.Chapter.Select(c => c).ToList();
             chapterViewModel.documents = _context.Documents.Select(m => m).ToList();
            
             ViewBag.Chapter = _context.Chapter.Select(t => t).ToList();
             ViewBag.Course = _context.Course.OrderBy(t => t.CourseName).ToList();
            return View(chapterViewModel);
           

            return View();
        }

       
      /*public async Task<IActionResult> CourseDetails([FromQuery] Guid Id)
        { 
            var course = await _context.Course.SingleOrDefaultAsync(x => x.CourseId == Id);
            
            if (course != null)
            {
                return View(new CourseViewModel
                {
                    Id = course.CourseId,
                    CourseName = course.CourseName,
                    Grade = course.Grade

                });
            }
           
                return View("Error");
           
           
        }
        */
       
        public async Task<IActionResult> GetCourses()
        {
            var courses = await (
                from c in _context.Course
                select new
                {
                    Id = c.CourseId,
                    CourseName = c.CourseName,
                    Grade = c.Grade

                }).ToListAsync();
           
            return Json(courses);
        }

        [HttpGet]
        public IActionResult CreateChapter()
        {
            ViewBag.Action = "Create";
            ViewBag.Course = _context.Course.Select(t => t).ToList();
            return View();
        }

        [HttpGet]
        public IActionResult UploadAttachment()
        {
            ViewBag.Chapter = _context.Chapter.Select(t => t).ToList();
            return View();
        }
        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCoursePostModel model)
        {
            /* if (!(await _userManager.IsInRoleAsync(user, "Administrator")))
                            {
                                throw new Exception($"You are not allowed to add courses, because you don't have the Administrator role assigned to you.");
                            }*/

            if (ModelState.IsValid)
            {
                var existingCourse = await _context.Course.SingleOrDefaultAsync(x => x.CourseName == model.CourseName);

                if (existingCourse == null)
                {
                    var course = new Course()
                    {
                        CourseId = Guid.NewGuid(),
                        CourseName = model.CourseName,
                        Grade = model.Grade
                    };
                    await _context.Course.AddAsync(course);

                    await _context.SaveChangesAsync();

                    return Json(course);
                }

                return BadRequest("This Course already Exists");

            }
            return BadRequest("Model is not valid");
        }

        [HttpPost]
        public IActionResult CreateChapter(ChapterViewModel chapterViewModel)
        {

            if (chapterViewModel == null)
            {
               
                var chapters = new List<Chapter>
                {
                    new Chapter{ChapterID= Guid.NewGuid(), ChapterName=chapterViewModel.ChapterName, Date = DateTime.Now, Description = chapterViewModel.Description,CourseId = chapterViewModel.CourseId}
                };


                chapters.ForEach(s => _context.Chapter.Add(s));
               
                _context.SaveChanges();
                ViewBag.Message = "Data saved successfully.";

            }
           
            ViewBag.Message = "Error while saving record.";
            return RedirectToAction("Course", "Courses");
        }
       
        [HttpPost]
        public IActionResult UploadAttachment(ChapterViewModel model)
        {
            if (model.attachment != null)
            {
                //write file to a physical path
                var uniqueFileName = SpClass.CreateUniqueFileExtension(model.attachment.FileName);
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "attachment");
                var filePath = Path.Combine(uploads, uniqueFileName);

                model.attachment.CopyTo(new FileStream(filePath, FileMode.Create));

                ViewBag.Chapter = _context.Chapter.Select(t => t).ToList();
                //save the attachment to the database
                Document document = new Document();
                document.FileName = uniqueFileName;
                document.ChapterID = model.ChapterID;
               
                
                document.attachment = SpClass.GetByteArrayFromImage(model.attachment);

                _context.Documents.Add(document);

                _context.SaveChanges();

            }

            return RedirectToAction("Course", "Courses");
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
            Document document = new Document();
            document = _context.Documents.Select(m => m).Where(m => m.FileID == ID).FirstOrDefault();

            string contentType = SpClass.GetContenttype(document.FileName);
            fileContent = (byte[])document.attachment;
            return new FileContentResult(fileContent, contentType);
        }

        [HttpGet]
        public IActionResult DeleteFile(int id)
        {
            var file = _context.Documents

                .FirstOrDefault(f => f.FileID == id);
            return View(file);
        }

        [HttpPost]
        public IActionResult DeleteFile(Document document)
        {
            _context.Documents.Remove(document);
            _context.SaveChanges();
            return RedirectToAction("Course", "Courses");
        }

    }
}
