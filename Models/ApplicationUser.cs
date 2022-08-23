using Microsoft.AspNetCore.Identity;

namespace Smart_E.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Status { get; set; } = "Active";
        public bool IsDeleted { get; internal set; }
        /*public int UsernameChangeLimit { get; set; } = 10;
public byte[] ProfilePicture { get; set; }*/
    }
}
