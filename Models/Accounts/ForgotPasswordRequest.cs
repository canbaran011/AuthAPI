using System.ComponentModel.DataAnnotations;

namespace AuthAPI.Models.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}