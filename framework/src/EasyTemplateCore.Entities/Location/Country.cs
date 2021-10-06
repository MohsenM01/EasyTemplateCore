namespace EasyTemplateCore.Entities.Location
{
    public class Country : BaseEntity
    {
        public int CountryNo { get; set; }
        public string CountryAbbr { get; set; }
        public string CountryName { get; set; }
        public string Remark { get; set; }
    }
}
