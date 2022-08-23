using Microsoft.AspNetCore.Mvc;
using Smart_E.Models;
using System.Diagnostics;
using Smart_E.Data;

namespace Smart_E.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { "test@gmail.com" },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}","Buhle")
                }
            };

            await _emailService.SendTestEmail(options);
            return View();
        }

        //public async Task<ViewResult> SendEmail()
        //{
           
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}