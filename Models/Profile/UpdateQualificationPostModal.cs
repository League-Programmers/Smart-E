﻿namespace Smart_E.Models.Profile
{
    public class UpdateQualificationPostModal
    {
        public Guid Id { get; set; }

        public string School { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
    }
}
