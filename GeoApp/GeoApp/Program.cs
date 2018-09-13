using System;
using System.Collections.Generic;
using System.Linq;

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
            WriteInWhite(" What would you like to do?\n");

            Console.WriteLine(" A) Show all countries");
            Console.WriteLine(" B) Show all religions");

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
            DisplayAllReligions();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" A) Choose a religion");
            Console.WriteLine(" B) Go back to main menu");


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
		    Console.WriteLine(" Write a letter and show all countries that start with the letter");
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
            Console.WriteLine("╔═╗┌─┐┌─┐╔═╗┌─┐┌─┐");
            Console.WriteLine("║ ╦├┤ │ │╠═╣├─┘├─┘");
            Console.WriteLine("╚═╝└─┘└─┘╩ ╩┴  ┴  ");
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
            Console.WriteLine();
            Console.WriteLine();
            WriteInWhiteWithoutNewLine(" Enter the id of the religion do you wish to see more information about: ");
            var religion = int.Parse(Console.ReadLine());

            ShowAppLogo();
            ReligionInfo(religion);
            WriteInWhite(" Countries");
            foreach (var country in dataAccess.GetCountriesByReligion(religion))
            {
                Console.WriteLine(" " + country.Name);
            }

        }
        private static void ReligionInfo(int religionId)
        {
            var religionList = dataAccess.GetAllReligions();

            foreach (var newItem in religionList)
            {
                if (newItem.Id == religionId)
                {
                    switch (newItem.Name)
                    {
                        case "Christianity":
                            Header(" Christianity\n");
                            Console.WriteLine(" " + SpliceText(@" Christianity is a religion based upon Jesus of Nazareth's life and his teachings. It is the largest religion in the world today with more than 2.2 billion followers.", 50));
                            break;
                        case "Islam":
                            Header(" Islam\n");
                            Console.WriteLine(" " + SpliceText(@" Islam is a monotheistic, Abrahamic religion that originated with the teachings of the Islamic prophet Muhammad, both a 7th century Arab religious and political figure.", 50));
                            break;
                        case "Hinduism":
                            Header(" Hindusim\n");
                            Console.WriteLine(" " + SpliceText(@" Hinduism is the 3rd largest religion in the world, after Christianity and Islam", 50));
                            break;
                        case "Buddhism":
                            Header(" Buddhism\n");
                            Console.WriteLine(" " + SpliceText(@" Buddhism is an extensive and internally diverse tradition with two main branches. With 360 million followers, Buddhism is the fourth largest religion in the world.", 50));
                            break;
                        case "Judaism":
                            Header(" Judaism\n");
                            Console.WriteLine(" " + SpliceText(@" The most important religious text of Judaism is the Torah and its laws are called Halakhah. Judaism teaches that there is one God. The Hebrew bible is called the Tanakh and followers of Judaism are Jews", 50));
                            break;
                        default: WriteInRed("meh"); Console.ReadKey(); PageMainMenu(); break;
                    }
                }
            }
            Console.WriteLine();
        }
        private static void Header(string v)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(v);
            Console.ResetColor();
            Console.WriteLine();
        }

        private static string SpliceText(string text, int lineLength)
        {
            var charCount = 0;
            var lines = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .GroupBy(w => (charCount += w.Length + 1) / lineLength)
                            .Select(g => string.Join(" ", g));

            return String.Join("\n ", lines.ToArray());
        }
        private static void WriteInWhiteWithoutNewLine(string v)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(v);
            Console.ResetColor();
        }
    }
}
