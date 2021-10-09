using System;

namespace LateralApp.Entities.Location
{
    public class Country
    {
        public Guid Id { get; set; }
        public int CountryNo { get; set; }
        public string CountryAbbr { get; set; }
        public string CountryName { get; set; }
        public string Remark { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
