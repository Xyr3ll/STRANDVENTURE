using System.ComponentModel.DataAnnotations;

namespace STRANDVENTURE.Models;

public class TeacherLoginViewModel 
{
    public InputModel Input { get; set; } = new();

    public string ErrorMessage { get; set; } = string.Empty;
    public string SuccessMessage { get; set; } = string.Empty;
    public string CaptchaImageBase64 { get; set; } = string.Empty;

    public class InputModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

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