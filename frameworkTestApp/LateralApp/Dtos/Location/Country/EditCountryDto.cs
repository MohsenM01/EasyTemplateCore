using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LateralApp.Dtos.Location.Country
{

    /// <summary>
    /// 
    /// </summary>
    public class EditCountryDto
    {

        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Country Abbr"),
         Required(AllowEmptyStrings = false),
         StringLength(3, MinimumLength = 3)]
        public string CountryAbbr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Country No"),
         Required(AllowEmptyStrings = false)]
        public int CountryNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Country Name"),
         Required(AllowEmptyStrings = false),
         StringLength(200, MinimumLength = 3)]
        public string CountryName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Remark"),
         StringLength(500, MinimumLength = 3)]
        public string Remark { get; set; }

    }
}