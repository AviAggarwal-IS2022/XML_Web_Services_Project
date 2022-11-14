using System.ComponentModel.DataAnnotations;

namespace XML_Web_Services_Project
{
    public class FeedbackForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string FeedbackCategory { get; set; }
        [Required]
        [Range(1,10)]
        public int Rating { get; set; }
        public string? Feedback { get; set; }
    }
}
