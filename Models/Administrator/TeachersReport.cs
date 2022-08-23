using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Administrator
{
    public class TeachersReport
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
        public string Qualification { get; set; }
        [Required]
        public string Subjects { get; set; }
        [Required]
        [Display(Name ="Targets Achieved")]
        public int TargetsAchieved { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
