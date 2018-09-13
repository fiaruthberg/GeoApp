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
