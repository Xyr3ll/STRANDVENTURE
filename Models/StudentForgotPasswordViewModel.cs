using System.ComponentModel.DataAnnotations;

namespace STRANDVENTURE.Models;

public class StudentForgotPasswordViewModel
{
    public InputModel Input { get; set; } = new();

    public string ErrorMessage { get; set; } = string.Empty;
    public string SuccessMessage { get; set; } = string.Empty;
    public string CaptchaImageBase64 { get; set; } = string.Empty;

    public class InputModel
    {
        [Required]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "LRN must be exactly 12 digits")]
        [Display(Name = "Learner Reference Number (LRN)")]
        public string LRN { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; } = DateTime.Today;

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        [Display(Name = "CAPTCHA")]
        public string CaptchaInput { get; set; } = string.Empty;
    }
}
