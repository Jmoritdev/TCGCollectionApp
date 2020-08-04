using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TCGCollectionApp.Data;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Data
{
    public class TCGCollectionContext : IdentityDbContext<User> {
        public TCGCollectionContext (DbContextOptions<TCGCollectionContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<MTGUserCard>()
                .HasKey(uc => new { uc.CardId, uc.UserId });
            builder.Entity<MTGUserCard>()
                .HasOne(uc => uc.Card)
                .WithMany(c => c.UserCards)
                .HasForeignKey(uc => uc.CardId);
            builder.Entity<MTGUserCard>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCards)
                .HasForeignKey(uc => uc.UserId);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<TCGCollectionApp.Models.MTGCard> MTGCard { get; set; }

        public DbSet<TCGCollectionApp.Models.MTGSet> MTGSet { get; set; }

        public DbSet<TCGCollectionApp.Models.MTGUserCard> MTGUserCard { get; set; }

        public DbSet<TCGCollectionApp.Data.User> User { get; set; }
    }
}
