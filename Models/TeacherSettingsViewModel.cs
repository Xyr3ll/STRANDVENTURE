using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding; // For BindNever
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation; // For ValidateNever

namespace STRANDVENTURE.Models;

public class TeacherSettingsViewModel
{
    // Account details (read-only for now)
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;

    // Not posted from the form; prevent model binding/validation from marking it invalid
    [BindNever]
    [ValidateNever]
    public Employee? Employee { get; set; }

    // Messages
    public string? SuccessMessage { get; set; }
    public string? ErrorMessage { get; set; }

    public ChangePasswordInput PasswordChange { get; set; } = new();

    public class ChangePasswordInput
    {
        [Required]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required]
        [Display(Name = "New Password")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string NewPassword { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}