﻿using System.Resources;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using Smart_E.Data;
using Smart_E.Models;
using Smart_E.Models.AdministrationViewModels;
using Smart_E.Models.Profile;

namespace Smart_E.Controllers
{

    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public ProfileController(ILogger<ProfileController> logger, ApplicationDbContext context ,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager
            )
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserQualification([FromQuery] string id)
        {
            var user = await (
                from u in _context.Users
                join q in _context.Qualifications
                    on u.QualificationId equals q.Id into data
                from d in data.DefaultIfEmpty()
                where u.Id == id
                select new
                {
                    Id = d.Id,
                    UserId = u.Id,
                    Description = d.Description,
                    QualificationType = d.QualificationType,
                    SchoolName = d.SchoolName,
                    YearAchieved = d.YearAchieved,
                    
                }).SingleOrDefaultAsync();

            return Json(user);
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var user = await (
                from u in _userManager.Users
                join ur in _context.UserRoles 
                    on u.Id equals ur.UserId
                    join r in _context.Roles
                    on ur.RoleId equals r.Id
                where u.Id == currentUser.Id
                select new ProfileViewModel()
                {
                    FirstName = u.FirstName,
                    Id = u.Id,
                    Surname = u.LastName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Role = r.Name

                }).SingleOrDefaultAsync();

            return View(user);

        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordPostModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                if (user != null)
                {

                    var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.Password);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignOutAsync();

                        return Json("Password Changed");
                    }

                    return BadRequest("Password could not be changed. Please make sure the above rules are applied.");

                }

                return Unauthorized("User not authorized");
            }

            return BadRequest("Model is not valid");

        }

    
        [HttpGet]
        public async Task<IActionResult> GetUserProfile([FromQuery] string id)
        {
            var user = await (
                from u in _context.Users
                where u.Id == id
                select new
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName  = u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    Email = u.Email
                }).SingleOrDefaultAsync();

            return Json(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserQualification([FromBody] UpdateQualificationPostModal modal, [FromQuery] string id)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.Id ==id);

                if (user!=null)
                {
                    if (user.QualificationId == Guid.Empty)
                    {
                        var quaification = new Qualifications()
                        {
                            Id = Guid.NewGuid(),
                            Description = modal.Description,
                            QualificationType = modal.Type,
                            YearAchieved = modal.Date
                        };
                        await _context.Qualifications.AddAsync(quaification);
                        await _context.SaveChangesAsync();

                        user.QualificationId = quaification.Id;

                        _context.Users.Update(user);
                        await _context.SaveChangesAsync();

                        return Json(quaification);

                    }
                    var qualifications =
                        await _context.Qualifications.SingleOrDefaultAsync(x => x.Id == modal.QualificationId);

                    if (qualifications != null)
                    {
                        qualifications.Description = modal.Description;
                        qualifications.QualificationType = modal.Type;
                        qualifications.SchoolName = modal.School;
                        qualifications.YearAchieved = modal.Date;
                        
                        _context.Qualifications.Update(qualifications);

                        await _context.SaveChangesAsync();

                        return Json(qualifications);

                    }
                    return BadRequest("Qualification not valid");
                }
                
                return BadRequest("User not valid");
            }

            return BadRequest("Modal not valid");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserInformation([FromBody] UpdateUserPostModal modal)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(x=>x.Id == modal.Id);

                if (user != null)
                {

                    user.FirstName = modal.FirstName;
                    user.LastName = modal.LastName;
                    user.PhoneNumber = modal.PhoneNumber;
                    user.Email = modal.Email;

                     _context.Users.Update(user);
                     await _context.SaveChangesAsync();
                     return Json(user);
                }

                return BadRequest("User does not exist");

            }
            return BadRequest("Modal not valid.");

        }
    }
}
