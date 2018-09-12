using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApp
{
    public class GovernmentPolity
    {
        public int Id { get; set; }
        public Polity Polity { get; set; }
    }

    public enum Polity
    {
        Republic, Monarchy
    }
}
