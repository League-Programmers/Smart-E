using Smart_E.Data;
using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Courses
{
    public class Question
    {
        [Key]
        public Guid QuestionID { get; set; }

        public string Questions { get; set; }

        public bool Active { get; set; }

        public bool MultipleChoice { get; set; }

        public Guid AssessmentId { get; set; }
        public virtual Assessment Assessment { get; set; }
    }
}
