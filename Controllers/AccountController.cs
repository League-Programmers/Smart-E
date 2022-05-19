using System.Net.Mail;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Extensions;
using Smart_E.Models.AdministrationViewModels;
using TechlaFieldService.Models.AccountViewModels;

namespace Smart_E.Controllers
{
   public class AccountController : Controller

    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;

        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {

            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, LastName = model.Surname, FirstName = model.FirstName };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);



                    /*await _emailService.SendMail(new SendMailRequestModel()
                    {
                        Attachments = new List<Attachment>(),
                        From = new EmailAddress()
                        {
                            Email = "no-reply@techla.co.za",
                            Name = "no-reply"
                        },
                        Headers = new Dictionary<string, string>(),
                        HtmlContents = "",
                        PlainTextContents = "",
                        ReplyTo = new EmailAddress() { Email = "no-reply@techla.co.za", Name = "no-reply" },
                        ReportingAttributes = new List<EmailEntryReportingAttributeModel>(),
                        ReportingIdentifier = "",
                        Subject = "",
                        To = new EmailAddress() { Email = user.Email, Name = $"{user.FirstName} {user.Surname}" }
                    });*/

                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    //_logger.LogInformation("User created a new account with password.");
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);

            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string reset, string userId, string code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }

            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == userId);

            if (user == null) throw new ApplicationException("User could not be verified");


            var model = new ResetPasswordViewModel
            {
                Code = code,
                Email = user.UserName
            };

            return View(model);
        }
    }
}
