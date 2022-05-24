using System.ComponentModel.DataAnnotations;

namespace Smart_E.Data
{
    public class HOD
    {
        [Key]
        public int HODID { get; set; }

        [Required]
        public string HODName { get; set; }

        [Required]
        public string HODSurname { get; set; }

        [Required]
        public string HODEmail { get; set; }

        [Required]
        public int HODPhoneNumber { get; set; }

        //[Required]
        //public int DepartmentID { get; set; }
    }
}
