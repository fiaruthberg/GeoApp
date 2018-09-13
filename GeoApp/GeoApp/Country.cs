using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApp
{
    public class Country
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Capital { get; set; }
		public Continent Continent { get; set; }
		public List<ReligionInCountry> ReligionInCountry { get; set; }
        public List<TerrainInCountry> TerrainInCountry { get; set; }
        public List<LanguageInCountry> LanguageInCountry { get; set; }
        public Climate Climate { get; set; }
        public GovernmentPolity GovernmentPolity { get; set; }
        public Region Region { get; set; }

    }
}
