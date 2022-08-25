namespace Smart_E.Data
{
    public class Chapter
    {
        public Guid ChapterID { get; set; }

        public string ChapterName { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
