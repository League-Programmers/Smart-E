using System.ComponentModel.DataAnnotations;

namespace Smart_E.Data
{
    public class HOD
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Targets { get; set; }
        [Required]
        public string Active { get; set; }
    }
}
