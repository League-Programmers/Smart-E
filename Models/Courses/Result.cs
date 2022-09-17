using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Courses
{
    public class Result
    {
        [Key]
        public int ResultID { get; set; }

        public string AnswerText { get; set; }

        public int QuestionID { set; get; }
        public virtual Question Question { set; get; }
    }
}
