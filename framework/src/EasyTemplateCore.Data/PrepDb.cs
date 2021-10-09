using System.Linq;
using EasyTemplateCore.Entities.Location;
using Microsoft.EntityFrameworkCore;

namespace EasyTemplateCore.Data
{
    public static class PrepDb
    {
        public static void SeedData(IUnitOfWork uow)
        {
            uow.Database.Migrate();
            if (uow.Set<Country>().Any()) return;
            uow.Set<Country>().AddRangeAsync(
                new Country
                {
                    CountryNo = 1,
                    CountryAbbr = "IRN",
                    CountryName = "IRAN"
                },
                new Country
                {
                    CountryNo = 2,
                    CountryAbbr = "TRK",
                    CountryName = "TURKEY"
                },
                new Country
                {
                    CountryNo = 3,
                    CountryAbbr = "USA",
                    CountryName = "The United States"
                }
            );
            uow.SaveChanges();
        }
    }
}