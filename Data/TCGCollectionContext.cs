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
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<TCGCollectionApp.Models.MTGCard> MTGCard { get; set; }

        public DbSet<TCGCollectionApp.Models.MTGSet> MTGSet { get; set; }
    }
}
