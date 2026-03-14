using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Venue
    {
        public int VenueID { get; set; }

        [Required]
        [Display(Name = "Venue Name")]
        public string NameOfVenue { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string VenueAddress { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string VenueLocation { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }
    }
}