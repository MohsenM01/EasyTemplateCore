using System;
using System.ComponentModel;

namespace LateralApp.Dtos.Location.Country
{
    /// <summary>
    /// 
    /// </summary>
    public class CountryDto
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Country Abbr")]
        public string CountryAbbr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Country No")]
        public int CountryNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Country Name")]
        public string CountryName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Remark")]
        public string Remark { get; set; }
    }
}
