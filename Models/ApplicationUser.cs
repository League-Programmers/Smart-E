using Microsoft.AspNetCore.Identity;

namespace Smart_E.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

       public bool Status { get; set; }
    }
}
