using System;
using System.Collections.Generic;

namespace GeoApp
{
    class Program
    {
        private static DataAccess dataAccess = new DataAccess();

        static void Main(string[] args)
        {
			ClearDatabase();
            InitDatabase();
            PageMainMenu();
        }
        private static void CountriesMenu()
        {
            ShowAppLogo();
            ShowAllCountryNames();
            Console.WriteLine();
            Console.WriteLine(" A) Filter countries by first letter");
            Console.WriteLine(" B) Filter countries by religion");
            Console.WriteLine(" C) Filter countries by language");
            Console.WriteLine(" D) Go back to main menu");

            ConsoleKey command = Console.ReadKey().Key;
            switch (command)
            {
                case ConsoleKey.A: ShowAllCountriesWithCertainLetter(); break;
                case ConsoleKey.B: DisplayCountriesByReligion(); break;
                case ConsoleKey.C: /* DisplayCountriesByLanguage() */; break;
                case ConsoleKey.D: PageMainMenu(); break;
                default: WriteInRed("meh"); Console.ReadKey(); PageMainMenu(); break;
            }
        }
        private static void PageMainMenu()
        {
            ShowAppLogo();
            WriteInWhite("What would you like to do?\n");

            Console.WriteLine("A) Show all countries");
            Console.WriteLine("B) Show all religions");

            ConsoleKey command = Console.ReadKey().Key;
            switch (command)
            {
                case ConsoleKey.A: CountriesMenu(); break;
                case ConsoleKey.B: ReligionsMenu(); break;
                default: WriteInRed("meh"); Console.ReadKey(); PageMainMenu(); break;
            }
        }
        private static void ReligionsMenu()
        {
            ShowAppLogo();

            Console.WriteLine(" A) Choose a religion");
            Console.WriteLine(" B) Go back to main menu");

            DisplayAllReligions();

            ConsoleKey command = Console.ReadKey().Key;
            switch (command)
            {
                case ConsoleKey.A: DisplayCountriesByReligion(); break;
                case ConsoleKey.B: PageMainMenu(); break;
                default: WriteInRed("meh"); Console.ReadKey(); PageMainMenu(); break;
            }
        }

        private static void DisplayAllReligions()
        {
            foreach (var item in dataAccess.GetAllReligions())
            {
                Console.WriteLine(item.Id + " " + item.Name);
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
        private static void ShowAppLogo()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" *********************************");
            Console.WriteLine();
            Console.WriteLine("              GeoApp");
            Console.WriteLine();
            Console.WriteLine(" *********************************");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
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
            dataAccess.PopulateSimpleTables();
            dataAccess.SaveChanges();
        }
        private static void DisplayCountriesByReligion()
        {
            WriteInWhiteWithoutNewLine(" Enter the id of the religion do you wish to see more information about: ");
            var religion = int.Parse(Console.ReadLine());

            Console.WriteLine();
            foreach (var country in dataAccess.GetCountriesByReligion(religion))
            {
                Console.WriteLine(" " + country.Name);
            }

        }

        private static void WriteInWhiteWithoutNewLine(string v)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(v);
            Console.ResetColor();
        }
    }
}
