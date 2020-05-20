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

            builder.Entity<Cuisine>()
                .HasData(
                new Cuisine { CuisineId = 1, CuisineName = "Mexican" },
                new Cuisine { CuisineId = 2, CuisineName = "American" },
                new Cuisine { CuisineId = 3, CuisineName = "Italian" },
                new Cuisine { CuisineId = 4, CuisineName = "Chinese" },
                new Cuisine { CuisineId = 5, CuisineName = "Japanese" },
                new Cuisine { CuisineId = 6, CuisineName = "French" },
                new Cuisine { CuisineId = 7, CuisineName = "Burgers" },
                new Cuisine { CuisineId = 8, CuisineName = "Pizza" },
                new Cuisine { CuisineId = 9, CuisineName = "Bar Food" },
                new Cuisine { CuisineId = 10, CuisineName = "Indian" },
                new Cuisine { CuisineId = 11, CuisineName = "Fast Food" },
                new Cuisine { CuisineId = 12, CuisineName = "Thai" },
                new Cuisine { CuisineId = 13, CuisineName = "Vietnamese" },
                new Cuisine { CuisineId = 14, CuisineName = "Breakfast" }


                );

        }
    }
}
