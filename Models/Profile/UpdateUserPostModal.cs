using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Profile
{
    public class UpdateUserPostModal
    {
        [Key]
        public Guid Id { get; set; }
        [Required]      
        public string FirstName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public bool Gender { get; set; }
    }
}
