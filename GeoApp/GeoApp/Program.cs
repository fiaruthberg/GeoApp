using System;
using System.Collections.Generic;

namespace GeoApp
{
    class Program
    {
        private static DataAccess dataAccess = new DataAccess();

        static void Main(string[] args)
        {
			var dataAccess = new DataAccess();
			ClearDatabase();
            InitDatabase(); /* BORIS */
            PageMainMenu(); /* SOFIA */
        }

        private static void PageMainMenu()
        {
            Console.Clear();
            WriteInWhite("What would you like to do?\n");

            Console.WriteLine("A) Show all countries");

            ConsoleKey command = Console.ReadKey().Key;
            switch (command)
            {
                case ConsoleKey.A: ShowAllCountriesInList() /* REZAN */; break;
                default: WriteInRed("meh"); Console.ReadKey(); PageMainMenu(); break;
            }
        }

        private static void ShowAllCountriesInList()
        {

			var showCountries = dataAccess.GetAllCountriesToList();

			foreach (var item in showCountries)
			{
				Console.WriteLine(item.Name + " " + item.Capital + " " + item.Continent + " " + item.TerrainInCountries + " " + item.Climate);
			}
        }
		private static void ShowAllCountriesWithCertainLetter()
		{
		    Console.WriteLine("Write a letter and show all countries that start with the letter");
			char input = char.Parse(Console.ReadLine());
			var showCountries = dataAccess.GetAllCountriesToListWithLetter(input);

			foreach (var item in showCountries)
			{
				Console.WriteLine(item.Name + " ");
			}

		}

		private static void ShowAllCountryNames()
		{
			var showCountries = dataAccess.GetAllCountriesToList();

			foreach (var item in showCountries)
			{
				Console.WriteLine(item.Name + " ");
			}

		}
		private static void WriteInWhite(string v)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(v);
            Console.ResetColor();
        }

        private static void WriteInRed(string v)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(v);
            Console.ResetColor();
        }

        private static void ClearDatabase()
        {
            dataAccess.ClearDatabase();
            dataAccess.SaveChanges();
        }

        private static void InitDatabase()
        {
            throw new NotImplementedException();
        }
        private static void DisplayCountriesByReligion(Religion religion)
        {
            List<Country> countries = dataAccess.GetCountriesByReligion(religion);

            foreach (var country in countries)
            {
                Console.WriteLine(country);
            }

        }
    }
}
