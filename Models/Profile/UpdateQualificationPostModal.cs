namespace Smart_E.Models.Profile
{
    public class UpdateQualificationPostModal
    {
        public Guid QualificationId { get; set; }
        public string Description { get; set; }
        public string School { get; set; }
        public string Type { get; set; }

        public DateTime Date { get; set; }

    }
}
