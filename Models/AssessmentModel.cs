using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models
{
    public class AssessmentModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Assessment")]
        public string AssessmentName { get; set; }
        [Display(Name = "Date Started")]
        public DateTime DateStarted { get; set; }
        [Display(Name = "Date Submitted")]
        public DateTime DateSubmitted { get; set; }
        public string Status { get; set; }
    }
}
