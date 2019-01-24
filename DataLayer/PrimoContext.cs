using System;
using DataLayer.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class PrimoContext : IdentityDbContext<User>
    {
        public PrimoContext(DbContextOptions<PrimoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Story>()
                .HasKey(s => s.ID);
        }

        public DbSet<Story> Stories { get; set; }
    }
}