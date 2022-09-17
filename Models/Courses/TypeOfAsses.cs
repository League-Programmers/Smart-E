using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Courses
{
    public class TypeOfAsses
    {
        [Key]
        public Guid typeAssesId { get; set; }

        public string typeAssesName { get; set; }
    }
}
