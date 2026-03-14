using EventEase.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventEase.Models
{
    public class Booking
    {
        public int BookingID { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Total Amount")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

       
        [Required]
        [Display(Name = "Number of Seats")]
        public int NumberOfSeats { get; set; }

        [Display(Name = "Booked At")]
        public DateTime BookedAt { get; set; } = DateTime.Now;

        // Foreign Keys
        public int EventID { get; set; }
        public int CustomerID { get; set; }

        // Navigation Properties
        [Display(Name = "Event")]
        public Event Event { get; set; }

        [Display(Name = "Customer")]
        public Customer Customer { get; set; }
    }
}