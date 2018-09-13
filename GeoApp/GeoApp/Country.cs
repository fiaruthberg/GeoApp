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
		public List<Continent> Continent { get; set; }
		public List<ReligionInCountry> ReligionInCountry { get; set; }
        public List<TerrainInCountry> TerrainInCountry { get; set; }

    }
}
