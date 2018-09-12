using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApp
{
    public class Government_Polity_
    {
        public int Id { get; set; }
        public Polity Polity { get; set; }
    }

    public enum Polity
    {
        Republic, Monarchy
    }
}
