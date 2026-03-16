using EventEase.Models;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Event
    {
        public int EventID { get; set; }

        [Required]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public TimeSpan StartOfEvent { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public TimeSpan EndOfEvent { get; set; }

        [Required]
        [Display(Name = "Total Seats")]
        public int TotalSeats { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        // Foreign Key
        public int VenueID { get; set; }

        // Navigation Property
        [Display(Name = "Venue")]
        public Venue? Venue { get; set; }
    }
}