using LateralApp.Entities.Location;
using Microsoft.EntityFrameworkCore;
using LateralApp.Entities.Location.Mappings;

namespace LateralApp.Data
{
    public class LateralAppContext : DbContext
    {

        public LateralAppContext(DbContextOptions<LateralAppContext> options) : base(options) { }

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryMap());

            modelBuilder.Entity<Country>()
                .HasIndex(b => b.CountryNo)
                .IsUnique();

            modelBuilder.Entity<Country>()
                .HasIndex(b => b.CountryName)
                .IsUnique();

            modelBuilder.Entity<Country>()
                .HasIndex(b => b.CountryAbbr)
                .IsUnique();
        }

        #endregion

    }
}