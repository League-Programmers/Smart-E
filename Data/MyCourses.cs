using DocumentFormat.OpenXml.Presentation;

namespace Smart_E.Data
{
    public class MyCourses
    {
        public Guid Id { get; set; }

        public Guid CourseId { get; set; }
        public string StudentId { get; set; }

        public Guid AssignmentId { get; set; }

        public float NewMark { get; set; }

        public bool Status { get; set; }


    }
}
