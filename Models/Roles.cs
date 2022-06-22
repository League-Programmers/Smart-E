using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
