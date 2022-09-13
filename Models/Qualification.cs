using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models
{
    public class Qualification
    {
        public Guid Id { get; set; }
        [Display(Name = "Qualification Type")]
        public string UserId { get; set; }
        public string QualificationType { get; set; }
        public string Description { get; set; }
        [Display(Name = "School Name")]
        public string SchoolName {get;set;}
        [Display(Name = "Year Achieved")]
        [DisplayFormat(DataFormatString ="YYYY")]
        public DateTime YearAchieved { get; set; }

    }
}
