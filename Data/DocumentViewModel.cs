namespace Smart_E.Data
{
    public class DocumentViewModel
    {
        public string FileName { set; get; }
        public IFormFile attachment { set; get; }
        public List<Document> documents { get; set; }
        public int ChapterID { set; get; }
        public virtual Chapter Chapter { set; get; }
    }
}
