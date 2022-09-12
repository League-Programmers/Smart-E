using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models
{
    public class Grade
    {
        [Key]
        public Guid GradeID { get; set; }

        public string Description{ get; set; }
    }
}
