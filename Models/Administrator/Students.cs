using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Grade { get; set; }
        [Required]
        public string Subjects { get; set; }
        [Required]
        public int Progress { get; set; }
        [Required]
        public string Active { get; set; }
    }
}
