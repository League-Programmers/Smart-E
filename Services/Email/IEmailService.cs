using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_E.Services.Email
{
    public interface IEmailService
    {
        public Task SendSubscriptionInviteAsync(string userId, string email);


    }
}
