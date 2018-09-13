using System;
using System.Collections.Generic;
using System.Linq;
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

		public List<Country> GetAllCountriesToList()
		{
			return context.Countries.ToList();
		}


		public List<Country> GetAllCountriesToListWithLetter(char input)
		{
			return context.Countries.Where(x => x.Name.StartsWith(input)).ToList();
        }

		internal List<Country> GetCountriesByReligion(int religionId)
		{
                List<Country> newList = new List<Country>();

                foreach (var religionInCountry in context.ReligionsInCountry.Where(x => x.ReligionId == religionId))
                {
                    newList.Add(religionInCountry.Country);
                }
                return newList;
        }

        internal List<Religion> GetAllReligions()
        {
            return context.Religions.ToList();
        }

        public void PopulateSimpleTables()
        {
            var europa = new Continent { Name = "Europe" };
            var africa = new Continent { Name = "Africa" };
            var asia = new Continent { Name = "Asia" };
            var northAmerica = new Continent { Name = "North America" };
            var southAmerica = new Continent { Name = "South America" };
            var oceania = new Continent { Name = "Oceania" };

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

            var christianity = new Religion { Name = "Christianity" };
            var islam = new Religion { Name = "Islam" };
            var hinduism = new Religion { Name = "Hinduism" };
            var buddhism = new Religion { Name = "Buddhism" };
            var judaism = new Religion { Name = "Judaism" };

            context.Religions.AddRange(christianity, islam, hinduism, buddhism, judaism);

            var desert = new Terrain { Type = TerrainType.Desert };
            var forest = new Terrain { Type = TerrainType.Forest };
            var plains = new Terrain { Type = TerrainType.Plains };
            var mountains = new Terrain { Type = TerrainType.Mountain };

            context.Terrains.AddRange(desert, forest, plains, mountains);

            var swedish = new Language { Name = "Swedish" };
            var english = new Language { Name = "English" };

            context.Languages.AddRange(swedish, english);

            var countryList = new List<Country>
            {
                new Country { Name = "Sweden", Capital = "Stockholm", Climate = temperate, Continent = europa, GovernmentPolity = monarchy,
                    Regions = new List<Region> { new Region { Name = "Svealand" }, new Region { Name = "Götaland" }, new Region { Name = "Norrland" } },
                    LanguageInCountries = new List<LanguageInCountry> { new LanguageInCountry { Language = swedish } },
                    ReligionInCountries = new List<ReligionInCountry> { new ReligionInCountry { Religion = christianity } },
                    TerrainInCountries = new List<TerrainInCountry> {new TerrainInCountry { Terrain = forest } } }

            };
            context.AddRange(countryList);
            context.SaveChanges();
        }

	}
}
