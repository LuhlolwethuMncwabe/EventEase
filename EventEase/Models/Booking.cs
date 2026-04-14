using EventEase.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventEase.Models
{
    // Represents a booking made by a customer for an event
    public class Booking
    {
        // Primary Key, a special identifier
        public int BookingID { get; set; }

        // Status of booking for example,  confirmed, pending,cancelled)
        [Required]
        public string Status { get; set; }

        // The total cost of the booking
        [Required]
        [Display(Name = "Total Amount")]
        [DataType(DataType.Currency)]

        [Range(0.01, 100000)]// this prevents long number input 
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        // Number of seats bookes
        [Required]
        [Display(Name = "Number of Seats")]
        [Range(1, 1000)] // This prevents 0 seat bookings 
        public int NumberOfSeats { get; set; }

        // Date and time the booking was made
        [Display(Name = "Booked At")]
        public DateTime BookedAt { get; set; } = DateTime.Now;

        // Foreign Keys
        public int EventID { get; set; } //links to the Event
        public int CustomerID { get; set; } // links to the customer

        // Navigation Properties
        //Aallows access to realted event object
        [Display(Name = "Event")]
        public Event? Event { get; set; }

        // Allows acess to related customer object
        [Display(Name = "Customer")]
        public Customer? Customer { get; set; }
    }
}