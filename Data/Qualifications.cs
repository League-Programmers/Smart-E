﻿using System.ComponentModel.DataAnnotations;

namespace Smart_E.Data
{
    public class Qualifications
    {
        public Guid Id { get; set; }
        public string QualificationType { get; set; }
        public string Description { get; set; }
        public string SchoolName {get;set;}

        public DateTime YearAchieved { get; set; }
    }
}
