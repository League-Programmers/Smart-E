using Smart_E.Data;

namespace Smart_E.Models.Courses
{
    public class ChapterViewModel
    {
        public Guid ChapterID { get; set; }

        public string ChapterName { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }
        
        public List<Chapter> chapters { get; set; }

        public Guid CourseId { get; set; }
        public  Course Course { get; set; }

    }
}
