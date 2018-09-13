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


	}
}
