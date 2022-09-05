using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;
using Smart_E.Models.Invites;

namespace Smart_E.Controllers
{
    public class InvitesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public InvitesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddParentInvite([FromBody] CreateParentInvitePostModal model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                var date = DateTime.Now;

                var userTo = await _context.Users.SingleOrDefaultAsync(x => x.Email == model.Email);

                if (userTo !=null)
                {
                    var invite= new Invite()
                    {
                        Id = Guid.NewGuid(),
                        InviteFrom = user.Id,
                        InviteTo = userTo.Id,
                        CreationDate = date,
                        Status = false,
                        Message = ""

                    };
                    await _context.Invites.AddAsync(invite);

                    await _context.SaveChangesAsync();

                    return Json(invite);
                }
                return BadRequest("There is no account with that email on our system.");
            }
            return BadRequest("Model is not valid");
        }


    }
}
