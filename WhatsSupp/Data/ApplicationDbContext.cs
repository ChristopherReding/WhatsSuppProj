using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhatsSupp.Models;

namespace WhatsSupp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<CuisineJxn> CuisinePreferences { get; set; }
        public DbSet<Diner> Diners { get; set; }
        public DbSet<PotentialMatch> PotentialMatches { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Name = "Diner",
                        NormalizedName = "DINER"
                    }
                    );
        }
    }
}
