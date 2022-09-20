using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.Primitives;

namespace Smart_E.Data
{
    public class Assignments
    {
        public Guid Id { get; set; }

        public string TeacherId { get; set; }

        public string Name { get; set; } 

        public float Mark { get; set; }
    }
}
