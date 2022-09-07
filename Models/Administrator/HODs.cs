using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Administrator
{
    public class HODs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Qualifications { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        public int PhoneNo { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
    }
}
