namespace Smart_E.Models
{
    public class Upload
    {
        public int Id { get; set; }
        public string SubmissionType { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public byte[] Attachment { get; set; }
    }
}
