using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Microsoft.AspNetCore.Identity;

namespace Smart_E.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [PersonalData]
        [Required]
        public string LastName { get; set; }

        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Role { get; set; }
        public byte[] ProfileImage { get; set; }

        public string ContentType { get; set; }

        public string ProfilePictureFileName { get; set; }

        public string Gender { get; set; }

    }
}
