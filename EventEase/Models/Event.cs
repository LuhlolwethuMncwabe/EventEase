using EventEase.Models;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    // Represents an event that customers can book
    public class Event
    {
        // Primary Key
        public int EventID { get; set; }

        //The date of the event
        [Required]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

         
        // the event start time
        [Required]
        [Display(Name = "Start Time")]
        public TimeSpan StartOfEvent { get; set; }

        //the event end time
        [Required]
        [Display(Name = "End Time")]
        public TimeSpan EndOfEvent { get; set; }

        // Total seats available
        [Required]
        [Display(Name = "Total Seats")]
        public int TotalSeats { get; set; }

        // The url for the event image
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        // Foreign Key
        public int VenueID { get; set; }

        // Navigation Property
        [Display(Name = "Venue")]
        public Venue? Venue { get; set; }
    }
}