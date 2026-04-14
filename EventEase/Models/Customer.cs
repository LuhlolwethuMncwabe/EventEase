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
        [StringLength(100)] // this prevent s overly long names
        [Display(Name = "Full Name")]
        public string FirstName { get; set; }

        // The customers email address with a validation format
        [Required]
        [EmailAddress]
        [StringLength (150)]          
        public string Email { get; set; }

        // The customers phone number with a validation format
        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        [StringLength(15)]
        public string PhoneNumber { get; set; }
    }
}
