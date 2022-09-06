using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Subjects
{
    public class CreateSubjectPostModel
    {
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public string Grade { get; set; }

    }
}
