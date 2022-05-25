﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public ProfileController(ILogger<ProfileController> logger, ApplicationDbContext context ,UserManager<ApplicationUser> userManager
            )
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        
        
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var user = await (
                from u in _userManager.Users
                where u.Id == currentUser.Id
                select new ProfileViewModel()
                {
                    FirstName = u.FirstName,
                    UserId = u.Id,
                    Surname = u.LastName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,

                }).SingleOrDefaultAsync();

            return View(user);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateUserInformation([FromBody] UpdateUserPostModal modal)
        {
            if (ModelState.IsValid)
            {

            }
            return BadRequest("Modal not valid.");

        }
        public async Task<IActionResult> ProfilePicture([FromQuery] string profileImageName)
        {
           /* var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user != null)
            {
                var memoryStream = new MemoryStream(user.ProfileImage) { Position = 0 };

                return new FileStreamResult(memoryStream, user.ContentType);
            }*/

            return new FileStreamResult(new MemoryStream(), "image/png");
        }

        public async Task<IActionResult> UploadProfileImage(IFormFile file)
        {
            try
            {

                if (file.ContentType == "image/bmp" || file.ContentType == "image/jpeg" || file.ContentType == "image/png")
                {
                   // var user = await _userManager.GetUserAsync(HttpContext.User);

                    /*if (user != null)
                    {
                        var fileName = Guid.NewGuid().ToString();

                        if (file.ContentType == "image/bmp")
                        {
                            fileName += ".bmp";
                        }
                        else if (file.ContentType == "image/jpeg")
                        {
                            fileName += ".jpg";
                        }
                        else if (file.ContentType == "image/png")
                        {
                            fileName += ".png";
                        }

                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);

                            user.ProfileImage = memoryStream.ToArray();

                            user.ContentType = file.ContentType;

                            user.ProfilePictureFileName = fileName;

                            await _userManager.UpdateAsync(user);

                        }

                        return Ok();
                    }*/
                }

                return BadRequest("Image type is not valid");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
