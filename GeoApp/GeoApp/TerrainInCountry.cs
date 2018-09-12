using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApp
{
    public class TerrainInCountry
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int TerrainId { get; set; }
        public Terrain Terrain { get; set; }
    }
}
