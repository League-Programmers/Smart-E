using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Courses
{
    public class Answer
    {
        [Key]
        public Guid AnswerID { get; set; }

        public string AnswerName { get; set; }
 
        public Guid QuestionID { set; get; }
        public virtual Question Question { set; get; }
    }
}
