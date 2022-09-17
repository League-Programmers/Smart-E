using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Events
{
    public class EventTypeModel
    {
        [Key]
        public int EventID { get; set; }
        [Required]
        public string EventType { get; set; }
        public char Status { get; set; }
    }
}
