using System.ComponentModel.DataAnnotations;

namespace Smart_E.Data
{
    public class Grade
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
