using Smart_E.Enums;
using System;

namespace Smart_E.Data
{
    public class Invite
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string InvitedBy { get; set; }

        public string Email { get; set; }

        public InviteStatusEnum.InviteStatus InviteStatus { get; set; }
    }
}