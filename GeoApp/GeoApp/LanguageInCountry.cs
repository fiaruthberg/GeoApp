using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApp
{
    public class LanguageInCountry
    {
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
