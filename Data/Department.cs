using Smart_E.Models;
using System.ComponentModel.DataAnnotations;

namespace Smart_E.Data
{
    public class Department
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name ="Department Name")]
        public string DeptName { get; set; }
        [Required]
        [Display(Name = "Head of Department ")]
        public string HODId { get;set; }
        [Required]
        [Display(Name = "Subjects")]
        public Guid CourseId { get; set; }

    }
}
