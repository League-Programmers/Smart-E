using Smart_E.Models;
using System.ComponentModel.DataAnnotations;

namespace Smart_E.Data
{
    public class Department
    {
        public Guid Id { get; set; }
        [Required]
        public string DeptName { get; set; }
        [Required]
        public string HODId { get;set; }
      

    }
}
