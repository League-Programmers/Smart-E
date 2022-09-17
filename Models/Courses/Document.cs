using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Courses
{
    public class Document
    {
        [Key]
        public int FileID { get; set; }

        public string FileName { set; get; }

        public byte[] attachment { set; get; }

        public Guid ChapterID { set; get; }
        public virtual Chapter Chapter { set; get; }
    }
}
