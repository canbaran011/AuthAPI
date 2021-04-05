using System.ComponentModel.DataAnnotations;

namespace AuthAPI.Models.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}