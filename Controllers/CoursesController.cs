﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;
using Smart_E.Models.Courses;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart_E.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;

        public CoursesController(IWebHostEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }
        
        public IActionResult Courses()
        {
            var courses = _context.Course
                        .OrderBy(c => c.CourseName).ToList(); 
            return View(courses);
           
        }
        
        public IActionResult CourseDetails([FromQuery] Guid? id)
        {
           
            
            ChapterViewModel chapterViewModel = new ChapterViewModel();
          
            chapterViewModel.chapters = _context.Chapter.OrderBy(c=> c.ChapterName).ToList();
           
            return View(chapterViewModel);
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
                    Id = c.Id,
                    CourseName = c.CourseName,
                    Grade = c.Grade

                }).ToListAsync();
           
            return Json(courses);
        }

        [HttpGet]
        public IActionResult CreateChapter()
        {
            ViewBag.Action = "Create";
            ViewBag.Course = _context.Course.OrderBy(t => t.CourseName).ToList();
            return View();
        }
        [HttpGet]
      

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
                        Id = Guid.NewGuid(),
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

            if (chapterViewModel != null)
            {

                var chapters = new List<Chapter>
                {
                    new Chapter{ChapterID= Guid.NewGuid(), ChapterName=chapterViewModel.ChapterName, Date = DateTime.Now, Description = chapterViewModel.Description,CourseId = chapterViewModel.Id}
                };


                chapters.ForEach(s => _context.Chapter.Add(s));

                _context.SaveChanges();
                ViewBag.Message = "Data saved successfully.";

            }
            ViewBag.Action = " Create";
            ViewBag.Message = "Error while saving record.";
            return RedirectToAction("CourseDetails", "Courses", new { id = chapterViewModel.Id });
        }
       

       


    }
}