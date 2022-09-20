namespace Smart_E.Models.Assignment
{
    public class CreateAssignmentPostModal
    {
        public string Name { get; set; }
        public Guid CourseId { get; set; }

        public float Mark { get; set; }

    }
}
