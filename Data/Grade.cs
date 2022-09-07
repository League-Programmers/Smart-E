using System.ComponentModel.DataAnnotations;

namespace Smart_E.Data
{
    public class Grade
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
