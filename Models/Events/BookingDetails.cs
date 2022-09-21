using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Events
{
    public class BookingDetails
    {
        [Key]
        public int BookingId { get; set; }
        public int BookingNo { get; set; }
        public DateTime BookingDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        public string BookingApproval { get; set; } 
        public DateTime BookingApprovalDate { get; set; }
        [Display(Name = "Status")]
        public bool BookingCompletedFlag { get; set; } = false;
        public string Description { get; set; }
    }
}
