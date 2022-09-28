namespace Smart_E.Models.MyStudent
{
    public class MyStudentsProgressViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }

        public string Grade { get; set; }

        public string TeacherId { get; set; }
        public string TeacherName { get; set; }

        public string TeacherEmail { get; set; }

    }
}
