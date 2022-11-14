using System.ComponentModel.DataAnnotations;

namespace XML_Web_Services_Project
{
    public class FeedbackForm
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string FeedbackFor { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Range(1,5)]
        public int Rating { get; set; }
        public string? Feedback { get; set; }
    }
}
