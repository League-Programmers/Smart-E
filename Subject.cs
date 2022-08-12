using Microsoft.AspNetCore.Mvc;

namespace Smart_E.Data
{
    public class Subject : Controller
    {
        public Guid SubjectCode { get; set; }
        public string SubjectName { get; set; }
    }

}
