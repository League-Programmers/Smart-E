using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Events
{
    public class EventBooking
    {
        [Key]
        public int BookingId { get; set; }
        [Display(Name = "Created By")]
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int EventTypeId { get; set; }
        [Required]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        
        [Display(Name = "Uploaded File")]
        public String FileName { get; set; }
        [Required]
        public byte[] FileContent { get; set; }
    }
}
