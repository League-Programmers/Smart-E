using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Courses
{
    public class CreateCoursePostModel
    {
        [Required]
        public string Name { get; set; }
     
    }
}
