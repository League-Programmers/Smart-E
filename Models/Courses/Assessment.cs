using Smart_E.Data;

namespace Smart_E.Models.Courses
{
    public class Assessment
    {
        public Guid AssessmentId { get; set; }

        public string AssessmentName { get; set; }

        public Guid CourseId { set; get; }
        public virtual Course Course { set; get; } 

        public Guid typeAssesId { set; get; }
       

        public int TotalMark { set; get; }

        public int Percentage { set; get; }

        public DateTime Created { set; get; }


    }
}
