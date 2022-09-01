using Microsoft.AspNetCore.Mvc;

namespace Smart_E.Data
{
    public class Subject : Controller
    {
        public Guid SubjId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DeptId { get; set; }
    }

}
