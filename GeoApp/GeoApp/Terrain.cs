using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApp
{
    public class Terrain
    {
        public int Id { get; set; }
        public TerrainType Type { get; set; }
    }
    public enum TerrainType
    {
        Desert,
        Forest,
        Plains,
        Mountain,
		rainForest,
    }
}
