using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_E.Models.Events
{
    public class EventBooking
    {
        [Key]
        public int BookingId { get; set; }
        [Display(Name = "Created By")]
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
