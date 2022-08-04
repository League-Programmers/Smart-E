using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_E.Enums
{
    public static class InviteStatusEnum
    {
        public enum InviteStatus
        {
            Waiting,
            Declined,
            Accepted
        }


        public static string GetInviteStatusName(InviteStatus status)
        {
            switch (status)
            {
                case InviteStatus.Waiting:
                    return "Waiting";
                case InviteStatus.Declined:
                    return "Declined";
                case InviteStatus.Accepted:
                    return "Accepted";
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

    }
}
