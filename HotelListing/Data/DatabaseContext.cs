using HotelListing.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasData(
                    new Country { Id = 1, Name = "South Africa", ShortName = "RSA" },
                    new Country { Id = 2, Name = "Canada", ShortName = "CA" },
                    new Country { Id = 3, Name = "Mexico", ShortName = "MX" }
                );

            modelBuilder.Entity<Hotel>()
                .HasData(
                    new Hotel { Id = 1, Name = "Arcadia", Address = "Address 1", Rating = 4.5, CountryId = 1 },
                    new Hotel { Id = 2, Name = "Sunnyside", Address = "Address 2", Rating = 5, CountryId = 2 },
                    new Hotel { Id = 3, Name = "Highveld", Address = "Address 3", Rating = 2, CountryId = 3 }
                );
        }
    }
}
