using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Smart_E.Data;

namespace Smart_E.Controllers
{

    public class ProfileController : Controller
    {
        /*private readonly ILogger<ProfileController> _logger;
        private readonly ApplicationDbContext _context;*/
        //private readonly UserManager<ApplicationUser> _userManager;

        /*public ProfileController(ILogger<ProfileController> logger, ApplicationDbContext context 
            //UserManager<ApplicationUser> userManager
            )
        {
            _logger = logger;
            _context = context;
            //_userManager = userManager;
        }*/
        public IActionResult Profile()
        {
            return View();
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
