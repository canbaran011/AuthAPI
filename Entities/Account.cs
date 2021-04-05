using System;
using System.Collections.Generic;
using AuthAPI.Entities;

namespace AuthAPI.Entities
{
    public partial class Account
    {
        public Account()
        {
            RefreshToken = new HashSet<RefreshToken>();
            RefreshTokens = new List<RefreshToken>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int AcceptTerms { get; set; }
        public Role Role { get; set; }
        public string VerificationToken { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public DateTime? Verified { get; set; }
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }

        public virtual ICollection<RefreshToken> RefreshToken { get; set; }
        public bool OwnsToken(string token)
        {
            
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}
