using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Departments
{
    public class DepartmentViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Department Name")]
        public string DeptName { get; set; }
        public string HODId { get; set; }
        public string HOD { get; set; }
        public Guid CourseId { get; set; }
        public string Subject { get; set; }
    }
}
