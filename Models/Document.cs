using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models
{
    public class Document
    {
        [Key]
        public int FileID { get; set; }

        public string FileName { set; get; }

        public byte[] attachment { set; get; }
        
    }
}
