using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace XML_Web_Services_Project
{
    public class FeedbackForm
    {
        [Required(ErrorMessage = "Please Enter Only Alphabets")]
        [StringLength(50)]
        [DisplayName("Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Email Address")]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Phone Number")]
        [Phone]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Feedback Category")]
        public string FeedbackFor { get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; }

        [DisplayName("Feedback Comments")]
        public string? Feedback { get; set; }
    }
}
