namespace EventEase.Models
{
    // Used for displaying error information in the User interface (UI)
    public class ErrorViewModel
    {
       
        // Stores request ID for debugging
        public string? RequestId { get; set; }

        // Returns true if RequestId is not empty
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
