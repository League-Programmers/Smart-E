namespace Smart_E.Models.MyStudent
{
    public class UpdateStudentAttendancePostModal
    {
        public Guid Id { get; set; }

        public int NoOfClassesAttended { get; set; }

        public bool Outstanding { get; set; }
    }
}
