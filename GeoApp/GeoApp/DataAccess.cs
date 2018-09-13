using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApp
{
    public class DataAccess
    {
        private readonly GeoContext context;
        public DataAccess()
        {
            context = new GeoContext();
        }
        internal void ClearDatabase()
        {
            foreach (var terrain in context.Terrains)
            {
                context.Remove(terrain);
            }
            foreach (var religion in context.Religions)
            {
                context.Remove(religion);
            }
            foreach (var language in context.Languages)
            {
                context.Remove(language);
            }
            foreach (var governmentPolity in context.GovernmentPolities)
            {
                context.Remove(governmentPolity);
            }
            foreach (var climate in context.Climates)
            {
                context.Remove(climate);
            }
            foreach (var continent in context.Continents)
            {
                context.Remove(continent);
            }
            foreach (var country in context.Countries)
            {
                context.Remove(country);
            }
            foreach (var region in context.Regions)
            {
                context.Remove(region);
            }
        }
		
        internal void SaveChanges()
        {
            context.SaveChanges();
        }

		public List<Country>GetAllCountriesToList()
		{
			var list = new List<Country>();
			
			return list;
		}

		public List<Country> GetAllCountriesToListWithLetter(string input)
		{
			var list = new List<Country>();

			return list;
		}

        public void PopulateClimates()
        {

        }

        internal List<Country> GetCountriesByReligion()
        {
            throw new NotImplementedException();
        }

        public void PopulateSimpleTables()
        {
            var europa = new Continent { Name = "Europe" };
            var africa = new Continent { Name = "Africa" };
            var asia = new Continent { Name = "Asia" };
            var northAmerica = new Continent { Name = "North America" };
            var southAmerica = new Continent { Name = "South America" };
            var oceania = new Continent { Name = "Oceania" };

            var continentList = new List<Continent>
            {
                africa,
                asia,
                northAmerica,
                southAmerica,
                europa,
                oceania
            };
            context.Continents.AddRange(continentList);

            var monarchy = new GovernmentPolity { Polity = Polity.Monarchy };
            var republic = new GovernmentPolity { Polity = Polity.Republic };

            var polityList = new List<GovernmentPolity>
            {
                monarchy,
                republic
            };
            context.GovernmentPolities.AddRange(polityList);

            var arctic = new Climate { Name = "Arctic" };
            var tropical = new Climate { Name = "Tropical" };
            var subTropical = new Climate { Name = "Sub-Tropical" };
            var temperate = new Climate { Name = "Temperate" };

            var climateList = new List<Climate>
            {
                arctic,
                tropical,
                subTropical,
                temperate
            };
            context.Climates.AddRange(climateList);

            var countryList = new List<Country>
            {
                new Country { Name = "Sweden", Capital = "Stockholm", Climate = temperate, Continent = europa, GovernmentPolity = monarchy,  }
            };
        }    

	}
}
