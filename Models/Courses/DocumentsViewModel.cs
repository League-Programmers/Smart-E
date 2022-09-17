namespace Smart_E.Models.Courses
{
    public class DocumentsViewModel
    {
        public string FileName { set; get; }
        public IFormFile attachment { set; get; }
        public List<Document> documents { get; set; }
        public int ChapterID { set; get; }
        public virtual Chapter Chapter { set; get; }
    }
}
