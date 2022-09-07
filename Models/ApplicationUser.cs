using Microsoft.AspNetCore.Identity;

namespace Smart_E.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Active { get; set; }
        /*public int UsernameChangeLimit { get; set; } = 10;
        public byte[] ProfilePicture { get; set; }*/

        public bool Status { get; set; }
        public string Role { get; set; }
    }
}
