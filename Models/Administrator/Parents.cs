using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Administrator
{
    public class Parents
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Student Name")]
        public int StudentName { get; set; }
        [Required]
        public string Subjects { get; set; }
        [Required]
        public string TeacherEmail { get; set; }
        [Required]
        public int Progress { get; set; }
        [Required]
        public string Active { get; set; }
    }
}
