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
			//ClearDatabase();
            //InitDatabase();
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
            bool startOver = true;

            while (startOver)
            {
                switch (command)
                {
                    case ConsoleKey.A: startOver = false; ShowAllCountriesWithCertainLetter(); break;
                    case ConsoleKey.B: startOver = false; DisplayCountriesByReligion(); break;
                    case ConsoleKey.C: startOver = false; DisplayCountriesByLanguage(); break;
                    case ConsoleKey.D: startOver = false; PageMainMenu(); break;
                    default: WriteInRed("\n Not a valid option. Please try again"); command = Console.ReadKey().Key; break;

                }
            }
        }
        private static void PageMainMenu()
        {
            ShowAppLogo();
            WriteInWhite(" What would you like to do?\n");

            Console.WriteLine(" A) Show all countries");
            Console.WriteLine(" B) Show all religions");
			Console.WriteLine(" C) Show all languages");

			ConsoleKey command = Console.ReadKey().Key;

            bool startOver = true;

            while (startOver)
            {
                switch (command)
                {
                    case ConsoleKey.A: startOver = false; CountriesMenu(); break;
                    case ConsoleKey.B: startOver = false; ReligionsMenu(); break;
                    case ConsoleKey.C: startOver = false; LanguageMenu(); break;
                    default: WriteInRed("\n Not a valid option. Please try again"); command = Console.ReadKey().Key; break;
                }
            }
        }

		private static void LanguageMenu()
		{
			ShowAppLogo();
			DisplayAllLanguages();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(" A) Choose a Language");
			Console.WriteLine(" B) Go back to main menu");


			ConsoleKey command = Console.ReadKey().Key;
            bool startOver = true;

            while (startOver)
            {
                switch (command)
                {
                    case ConsoleKey.A: startOver = false; DisplayCountriesByLanguage(); break;
                    case ConsoleKey.B: startOver = false; PageMainMenu(); break;
                    default: WriteInRed("\n Not a valid option. Please try again"); command = Console.ReadKey().Key; break;
                }
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
            bool startOver = true;

            while (startOver)
            {
                switch (command)
                {
                    case ConsoleKey.A: startOver = false; DisplayCountriesByReligion(); break;
                    case ConsoleKey.B: startOver = false; PageMainMenu(); break;
                    default: WriteInRed("\n Not a valid option. Please try again"); command = Console.ReadKey().Key; break;

                }
            }
        }

        private static void DisplayAllReligions()
        {
            foreach (var item in dataAccess.GetAllReligions())
            {
                Console.WriteLine(" " + item.Id + " " + item.Name);
            }
        }

		private static void DisplayAllLanguages()
		{
			foreach (var item in dataAccess.GetAllLanguages())
			{
				Console.WriteLine(" " + item.Id + " " + item.Name);
			}
		}




		private static void ShowAllCountriesInList()
        {

			var showCountries = dataAccess.GetAllCountriesToList();

			foreach (var item in showCountries)
			{
				Console.WriteLine(" " + item.Name + " " + item.Capital + " " + item.Continent + " " + item.TerrainInCountries + " " + item.Climate);
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
            Console.WriteLine("                            ");
            Console.WriteLine("   ╔═╗┌─┐┌─┐╔═╗┌─┐┌─┐       ");
            Console.WriteLine("   ║ ╦├┤ │ │╠═╣├─┘├─┘       ");
            Console.WriteLine("   ╚═╝└─┘└─┘╩ ╩┴  ┴         ");
            Console.WriteLine("                            ");
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

		private static void DisplayCountriesByLanguage()
		{
			Console.WriteLine();
			Console.WriteLine();
			WriteInWhiteWithoutNewLine(" Enter the id of the language to see in which countries it is spoken: ");
			var language = int.Parse(Console.ReadLine());

			foreach (var country in dataAccess.GetCountriesByLanguage(language))
			{
				Console.WriteLine(" " + country.Country.Name);
			}

		}


		private static void DisplayCountriesByReligion()
        {
            Console.WriteLine();
            Console.WriteLine();
            WriteInWhiteWithoutNewLine(" Enter the id of the religion do you wish to see more information about: ");
            var religion = int.Parse(Console.ReadLine());

            bool myBool = dataAccess.ValidateReligion(religion);

            while(dataAccess.ValidateReligion(religion) == false)
            {
                WriteInRed("Are you sure you entered a valid id?");
                WriteInWhiteWithoutNewLine("Please try again: ");
                religion = int.Parse(Console.ReadLine());
                myBool = dataAccess.ValidateReligion(religion);
            }

            ShowAppLogo();
            ReligionInfo(religion);
            WriteInWhite(" Countries with chosen religion");
            foreach (var country in dataAccess.GetCountriesByReligion(religion))
            {
                Console.WriteLine(" " + country.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to all religions");
            Console.ReadKey();
            ReligionsMenu();
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
                            Console.WriteLine(" " + SpliceText(@" Christianity is a religion based upon Jesus of Nazareth's life and his teachings. It is the largest religion in the world today with more than 2.2 billion followers."));
                            break;
                        case "Islam":
                            Header(" Islam\n");
                            Console.WriteLine(" " + SpliceText(@" Islam is a monotheistic, Abrahamic religion that originated with the teachings of the Islamic prophet Muhammad, both a 7th century Arab religious and political figure."));
                            break;
                        case "Hinduism":
                            Header(" Hindusim\n");
                            Console.WriteLine(" " + SpliceText(@" Hinduism is the 3rd largest religion in the world, after Christianity and Islam"));
                            break;
                        case "Buddhism":
                            Header(" Buddhism\n");
                            Console.WriteLine(" " + SpliceText(@" Buddhism is an extensive and internally diverse tradition with two main branches. With 360 million followers, Buddhism is the fourth largest religion in the world."));
                            break;
                        case "Judaism":
                            Header(" Judaism\n");
                            Console.WriteLine(" " + SpliceText(@" The most important religious text of Judaism is the Torah and its laws are called Halakhah. Judaism teaches that there is one God. The Hebrew bible is called the Tanakh and followers of Judaism are Jews"));
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

        private static string SpliceText(string text)
        {
            var charCount = 0;
            var lines = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .GroupBy(w => (charCount += w.Length + 1) / 30)
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
