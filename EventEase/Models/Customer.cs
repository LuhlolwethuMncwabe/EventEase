using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    //reresent sa user or a customer who made the booking 
    public class Customer
    {
        //primary key
        public int CustomerID { get; set; }

        //The customers full name 
        [Required]
        [Display(Name = "Full Name")]
        public string FirstName { get; set; }

        // The customers email address with a validation format
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // The customers phone number with a validation format
        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
