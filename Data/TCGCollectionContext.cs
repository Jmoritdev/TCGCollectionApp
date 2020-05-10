using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Models
{
    public class TCGCollectionContext : DbContext
    {
        public TCGCollectionContext (DbContextOptions<TCGCollectionContext> options)
            : base(options)
        {
            
        }

        public DbSet<TCGCollectionApp.Models.MTGCard> MTGCard { get; set; }

        public DbSet<TCGCollectionApp.Models.MTGSet> MTGSet { get; set; }
    }
}
