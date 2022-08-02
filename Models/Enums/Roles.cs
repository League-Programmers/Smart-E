using System.ComponentModel.DataAnnotations;

namespace Smart_E.Enums
{
    public enum Roles
    {
        Parent,
        Administrator,
        Student,
        [Display(Name ="Head of Department")]
        HOD,
        Teacher
    }
}
