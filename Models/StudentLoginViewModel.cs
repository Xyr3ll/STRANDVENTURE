using System.ComponentModel.DataAnnotations;

namespace STRANDVENTURE.Models;

public class StudentLoginViewModel 
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
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Display(Name = "CAPTCHA")]
        public string CaptchaInput { get; set; } = string.Empty;

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}