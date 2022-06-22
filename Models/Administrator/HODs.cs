using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Administrator
{
    public class HODs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public int Targets { get; set; }
        [Required]
        public string Active { get; set; }
    }
}
