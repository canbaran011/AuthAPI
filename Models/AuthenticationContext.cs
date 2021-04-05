using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using AuthAPI.Entities;

#nullable disable

namespace AuthAPI.Models
{
    public partial class AuthenticationContext : DbContext
    {
        private readonly IConfiguration Configuration;
        public AuthenticationContext()
        {
        }

        public AuthenticationContext(DbContextOptions<AuthenticationContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordReset).HasColumnType("datetime");

                entity.Property(e => e.ResetToken)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ResetTokenExpires).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.VerificationToken)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Verified).HasColumnType("datetime");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshToken");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedByIp)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Expires).HasColumnType("datetime");

                entity.Property(e => e.ReplacedByToken)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Revoked).HasColumnType("datetime");

                entity.Property(e => e.RevokedByIp)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.AccountId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefreshToken_Accounts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
