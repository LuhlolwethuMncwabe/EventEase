using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    // Represents a location where events take place
    public class Venue
    {
        // Primary key
        public int VenueID { get; set; }

        //The Name of the venue
        [Required]
        [Display(Name = "Venue Name")]
        public string NameOfVenue { get; set; }

        // the dddress of the venue
        [Required]
        [Display(Name = "Address")]
        public string VenueAddress { get; set; }

        // the maximum number of people the venue can hold
        [Required]
        public int Capacity { get; set; }

        // the location in which the event will be taking place (city)
        [Required]
        [Display(Name = "Location")]
        public string VenueLocation { get; set; }

        //contact information (email) for the venue
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Image representing the venue
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }
    }
}