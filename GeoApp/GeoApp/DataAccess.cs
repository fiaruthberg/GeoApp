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

		public void PopulateClimates()
		{

		}

		internal List<Country> GetCountriesByReligion(Religion religion)
		{
                List<Country> newList = new List<Country>();

                foreach (var religionInCountry in context.ReligionsInCountry.Where(x => x.Religion == religion))
                {
                    newList.Add(religionInCountry.Country);
                }

                return newList;
        }

        public void PopulateContinets()
        {

        }

        public void PopulateCountries()
        {

        }

        public void PopulatePolities()
        {

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

            var christendom = new Religion { Name = "Christianity" };
            var islam = new Religion { Name = "Islam" };
            var hinduism = new Religion { Name = "Hinduism" };
            var buddhism = new Religion { Name = "Buddhism" };
            var judaism = new Religion { Name = "Judaism" };

            var desert = new Terrain { Type = TerrainType.Desert };
            var forest = new Terrain { Type = TerrainType.Forest };
            var plains = new Terrain { Type = TerrainType.Plains };
            var mountains = new Terrain { Type = TerrainType.Mountain };

            //var religionlist = new List<Religion>
            //{
            //    christendom,
            //    islam,
            //    hinduism,
            //    buddhism,
            //    judaism
            //};
            //context.Religions.AddRange(religionlist);

            var swedish = new Language { Name = "Swedish" };
            var english = new Language { Name = "English" };

            context.Languages.AddRange(swedish, english);

            var countryList = new List<Country>
            {
                new Country { Name = "Sweden", Capital = "Stockholm", Climate = temperate, Continent = europa, GovernmentPolity = monarchy,
                    Region = new List<Region> { new Region { Name = "Svealand" }, new Region { Name = "Götaland" }, new Region { Name = "Norrland" } },
                    LanguageInCountry = new List<LanguageInCountry> { new LanguageInCountry { Language = swedish } },
                    ReligionInCountry = new List<ReligionInCountry> { new ReligionInCountry { Religion = christendom } },
                    TerrainInCountry = new List<TerrainInCountry> {new TerrainInCountry { Terrain = forest }
            };
        }    

	}
}
