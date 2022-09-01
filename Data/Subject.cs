using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Smart_E.Data
{
    public class Subject : Controller
    {
        [Key]
        public Guid SubjId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int DeptId { get; set; }
    }

}
