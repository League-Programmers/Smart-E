using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Courses
{
    public class Choice
    {
        [Key]
        public Guid OptionID { get; set; }

        public string OptionName { get; set; }

        public Guid QuestionID { set; get; }
        public virtual Question Question { set; get; }
    }
}
