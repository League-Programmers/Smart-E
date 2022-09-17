using System.ComponentModel.DataAnnotations;

namespace Smart_E.Models.Events
{
    public class BookingDetails
    {
        [Key]
        public int BookingId { get; set; }
        public string BookingNo { get; set; }
        public DateTime BookingDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        public char BookingApproval { get; set; }
        public DateTime BookingApprovalDate { get; set; }
        public char BookingCompletedFlag { get; set; }
    }
}
