using System.ComponentModel.DataAnnotations;

namespace XML_Web_Services_Project
{
    public class FeedbackForm
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FeedbackFor { get; set; }
        public int Rating { get; set; }
        public string? Feedback { get; set; }
    }
}
