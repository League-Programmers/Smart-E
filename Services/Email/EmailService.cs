using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Enums;
using Smart_E.Services.Email;

namespace Smart_E.Email
{
    public class EmailService:IEmailService
    {

        private readonly ApplicationDbContext _context;


        public EmailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendSubscriptionInviteAsync(string userId, string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);

            if (user != null)
            {
               var existingInvite = await _context.Invites.SingleOrDefaultAsync(x => x.Email == email.ToLower() && x.InviteStatus == InviteStatusEnum.InviteStatus.Waiting);

                 if (existingInvite == null)
                 {
                     var invite = new Data.Invite()
                     {
                        Id = Guid.NewGuid(),
                        CreationDate = DateTime.UtcNow,
                        Email = email.ToLower(),
                        InvitedBy = user.Id,
                        InviteStatus = InviteStatusEnum.InviteStatus.Waiting,
                      };

                      await _context.Invites.AddAsync(invite);
                            
                      await _context.SaveChangesAsync();

                      return;

                 }
                 else
                 {
                     existingInvite.InvitedBy = user.Id;

                       _context.Update(existingInvite);

                       await _context.SaveChangesAsync();

                       return;
                 }
                 throw new Exception("You can't send a invite.");
            }

           throw new Exception("You can't send a invite.");
               
        }


    }
}
