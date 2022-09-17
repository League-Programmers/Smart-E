namespace Smart_E.Models.Courses
{
    public class QuestionOptionViewModel
    {
        public Guid AssessmentId { get; set; } 
        public string QuestionName { get; set; }
        public List<String> ListOfOptions { get; set; }
        public int AnswerText { get; set; }
    }

    
}
