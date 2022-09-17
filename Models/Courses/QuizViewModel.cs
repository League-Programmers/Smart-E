using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Smart_E.Data;

namespace Smart_E.Models.Courses
{
    public class QuizViewModel
    {
        public Guid AssessmentId { get; set; }

        public string AssessmentName { get; set; }

        public Guid CourseId { set; get; }
        public virtual Course Course { set; get; }

        public Guid typeAssesId { set; get; }
        public virtual TypeOfAsses TypeOfAsses { set; get; }

        public int TotalMark { set; get; }

        public int Percentage { set; get; }

        public DateTime Created { set; get; }


        public string Questions { get; set; }

        public string OptionName { get; set; }

        public IEnumerable<SelectListItem> ListOfAssessments { get; set; }


    }
}
