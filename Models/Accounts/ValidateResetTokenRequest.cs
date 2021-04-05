using System.ComponentModel.DataAnnotations;

namespace AuthAPI.Models.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}