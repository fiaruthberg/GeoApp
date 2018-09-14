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
			//RecreateDatabase();
			//InitDatabase();
			PageMainMenu();
		}
		private static void CountriesMenu()
		{
			ShowAppLogo();
			ShowAllCountryNames();
			Console.WriteLine();
			Console.WriteLine(" [A] Filter countries by first letter");
			Console.WriteLine(" [B] Filter countries by religion");
			Console.WriteLine(" [C] Filter countries by language");
			Console.WriteLine(" [D] Go back to main menu");

			ConsoleKey command = Console.ReadKey().Key;
			bool startOver = true;

            while (startOver)
            {
                switch (command)
                {
                    case ConsoleKey.A: startOver = false; ShowAllCountriesWithCertainLetter(); break;
                    case ConsoleKey.B: startOver = false; ReligionsMenu(); break;
                    case ConsoleKey.C: startOver = false; LanguageMenu(); break;
                    case ConsoleKey.D: startOver = false; PageMainMenu(); break;
                    default: WriteInRed("\n Not a valid option. Please try again"); command = Console.ReadKey().Key; break;

                }
            }
        }
        private static void PageMainMenu()
        {
            ShowAppLogo();
            Console.CursorVisible = false;
            WriteInWhite(" What would you like to do?\n");

            Console.WriteLine(" [A] Show all countries");
            Console.WriteLine(" [B] Show all religions");
            Console.WriteLine(" [C] Show all languages");
            Console.WriteLine(" [D] Show all continents");
            Console.WriteLine(" [E] Show all terrains");
            Console.WriteLine(" [F] Show all climates");
            Console.WriteLine(" [G] Show all info about countries");
            Console.WriteLine(" Press [esc] to EXIT");

			ConsoleKey command = Console.ReadKey().Key;

			bool startOver = true;

			while (startOver)
			{
				switch (command)
				{
					case ConsoleKey.A: startOver = false; CountriesMenu(); break;
					case ConsoleKey.B: startOver = false; ReligionsMenu(); break;
					case ConsoleKey.C: startOver = false; LanguageMenu(); break;
					case ConsoleKey.D: startOver = false; ContinentMenu(); break;
					case ConsoleKey.E: startOver = false; TerrainMenu(); break;
					case ConsoleKey.F: startOver = false; ClimateMenu(); break;
					case ConsoleKey.G: startOver = false; ShowAllCountriesInfo(); break;
					case ConsoleKey.Escape: startOver = false; break;					
					default: WriteInRed("\n Not a valid option. Please try again"); command = Console.ReadKey().Key; break;
				}
			}
		}

		private static void ShowAllCountriesInfoMenu()
		{
			ShowAllCountriesInfo();
		}
		private static void ClimateMenu()
		{
			ShowAppLogo();
			DisplayAllClimates();

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(" [A] Choose a climate");
			Console.WriteLine(" [B] Go back to main menu");


			ConsoleKey command = Console.ReadKey().Key;
			bool startOver = true;

			while (startOver)
			{
				switch (command)
				{
					case ConsoleKey.A: startOver = false; DisplayCountriesByClimate(); break;
					case ConsoleKey.B: startOver = false; PageMainMenu(); break;
					default: WriteInRed("\n Not a valid option. Please try again"); command = Console.ReadKey().Key; break;

				}
			}
		}

		private static void DisplayCountriesByClimate()
		{
			Console.WriteLine();
			Console.WriteLine();
			WriteInWhiteWithoutNewLine(" Enter the id of the climate do you wish to see a list of countries with chosen terrain: ");
			var climateId = int.Parse(Console.ReadLine());

			bool myBool = dataAccess.ValidateClimate(climateId);

            while (myBool == false)
            {
                WriteInRed(" Are you sure you entered a valid id?");
                WriteInWhiteWithoutNewLine(" Please try again: ");
                climateId = int.Parse(Console.ReadLine());
                myBool = dataAccess.ValidateReligion(climateId);
            }

            ShowAppLogo();
            WriteInWhite(" Countries with chosen climate");
            foreach (var country in dataAccess.GetCountriesByClimate(climateId))
            {
                Console.WriteLine(" " + country.Name);
            }
            Console.WriteLine();
            Console.WriteLine(" Press any key to go back to all climates");
            Console.ReadKey();
            ClimateMenu();
        }

		private static void DisplayAllClimates()
		{
			foreach (var item in dataAccess.GetAllClimates())
			{
				Console.WriteLine(" " + item.Id + " " + item.Name);
			}
		}
		private static void TerrainMenu()
		{
			ShowAppLogo();
			DisplayAllTerrains();

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(" [A] Choose a terrain");
			Console.WriteLine(" [B] Go back to main menu");


			ConsoleKey command = Console.ReadKey().Key;
			bool startOver = true;

			while (startOver)
			{
				switch (command)
				{
					case ConsoleKey.A: startOver = false; DisplayCountriesByTerrain(); break;
					case ConsoleKey.B: startOver = false; PageMainMenu(); break;
					default: WriteInRed("\n Not a valid option. Please try again"); command = Console.ReadKey().Key; break;

				}
			}
		}

		private static void DisplayAllTerrains()
		{
			foreach (var item in dataAccess.GetAllTerrains())
			{
				Console.WriteLine(" " + item.Id + " " + item.Type);
			}
		}

		private static void DisplayCountriesByTerrain()
		{
			Console.WriteLine();
			Console.WriteLine();
			WriteInWhiteWithoutNewLine(" Enter the id of the terrain do you wish to see a list of countries with chosen terrain: ");
			var terrainId = int.Parse(Console.ReadLine());

			bool myBool = dataAccess.ValidateTerrain(terrainId);

            while (myBool == false)
            {
                WriteInRed(" Are you sure you entered a valid id?");
                WriteInWhiteWithoutNewLine(" Please try again: ");
                terrainId = int.Parse(Console.ReadLine());
                myBool = dataAccess.ValidateTerrain(terrainId);
            }

            ShowAppLogo();
            WriteInWhite(" Countries with chosen terrain");
            foreach (var country in dataAccess.GetCountriesByTerrain(terrainId))
            {
                Console.WriteLine(" " + country.Name);
            }
            Console.WriteLine();
            Console.WriteLine(" Press any key to go back to all terrains");
            Console.ReadKey();
            TerrainMenu();
        }

		private static void ContinentMenu()
		{
			ShowAppLogo();
			DisplayAllContinents();

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(" [A] Choose a continent");
			Console.WriteLine(" [B] Go back to main menu");


			ConsoleKey command = Console.ReadKey().Key;
			bool startOver = true;

			while (startOver)
			{
				switch (command)
				{
					case ConsoleKey.A: startOver = false; DisplayCountriesByContinent(); break;
					case ConsoleKey.B: startOver = false; PageMainMenu(); break;
					default: WriteInRed("\n Not a valid option. Please try again"); command = Console.ReadKey().Key; break;

				}
			}
		}

		private static void DisplayCountriesByContinent()
		{
			Console.WriteLine();
			Console.WriteLine();
			WriteInWhiteWithoutNewLine(" Enter the id of the continent do you wish to see more information about: ");
			var continentId = int.Parse(Console.ReadLine());

			bool myBool = dataAccess.ValidateContinent(continentId);

            while (myBool == false)
            {
                WriteInRed(" Are you sure you entered a valid id?");
                WriteInWhiteWithoutNewLine(" Please try again: ");
                continentId = int.Parse(Console.ReadLine());
                myBool = dataAccess.ValidateContinent(continentId);
            }

            ShowAppLogo();
            ContinentInfo(continentId);
            Console.WriteLine();
            WriteInWhite(" Countries in chosen continent");
            foreach (var country in dataAccess.GetCountriesByContinent(continentId))
            {
                Console.WriteLine(" " + country.Name);
            }
            Console.WriteLine();
            Console.WriteLine(" Press any key to go back to all continents");
            Console.ReadKey();
            ContinentMenu();
        }

		private static void ContinentInfo(int continentId)
		{
			var continentList = dataAccess.GetAllContinents();

			foreach (var newItem in continentList)
			{
				if (newItem.Id == continentId)
				{
					switch (newItem.Name)
					{
						case "Europe":
							Header(" Europe\n");
							Console.WriteLine(" " + SpliceText(@" Europe is named after a Phoenician princess called Europa; she was seduced by Greek God Zeus when he disguised himself as a bull."));
							break;
						case "Oceania":
							Header(" Oceania\n");
							Console.WriteLine(" " + SpliceText(@" Much of Oceania is sparsely populated and there are more sheep in Oceania than people. Australia was first used as a prison colony by Britain where they would send unwanted criminals and outcasts."));
							break;
						case "North America":
							Header(" North America\n");
							Console.WriteLine(" " + SpliceText(@"  North America is the third largest continent in world, ranking just below Asia and Africa (which are the first and second largest continents, respectively)."));
							break;
						case "Africa":
							Header(" Africa\n");
							Console.WriteLine(" " + SpliceText(@" Africa covers 6 percent of the earth's total surface and 20.4 percent of the total land area."));
							break;
						case "Asia":
							Header(" Asia\n");
							Console.WriteLine(" " + SpliceText(@" With around 30 percent of the earth’s surface area, Asia is the largest of the seven continents on earth."));
							break;
						case "South America":
							Header(" South America\n");
							Console.WriteLine(" " + SpliceText(@" Five of the top 50 largest cities in the world are located in South America, and starting with the largest, these are Sao Paulo, Lima, Bogota, Rio, and Santiago."));
							break;
						default: WriteInRed("meh"); Console.ReadKey(); PageMainMenu(); break;
					}
				}
			}
		}
		private static void DisplayAllContinents()
		{
			foreach (var item in dataAccess.GetAllContinents())
			{
				Console.WriteLine(" " + item.Id + " " + item.Name);
			}
		}

		private static void LanguageMenu()
		{
			ShowAppLogo();
			DisplayAllLanguages();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(" [A] Choose a Language");
			Console.WriteLine(" [B] Go back to main menu");


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
			Console.WriteLine(" [A] Choose a religion");
			Console.WriteLine(" [B] Go back to main menu");


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
            WriteInWhiteWithoutNewLine("\n Write a letter and show all countries that start with the letter: ");
            char input = char.Parse(Console.ReadLine().ToUpper());
            var showCountries = dataAccess.GetAllCountriesToListWithLetter(input);

            foreach (var item in showCountries)
            {
                Console.WriteLine(" " + item.Name + " ");
            }
            Console.WriteLine();
            Console.WriteLine(" Press any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();
        }
        private static void ShowAppLogo()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                             ");
            Console.WriteLine("    ╔═╗┌─┐┌─┐╔═╗┌─┐┌─┐       ");
            Console.WriteLine("    ║ ╦├┤ │ │╠═╣├─┘├─┘       ");
            Console.WriteLine("    ╚═╝└─┘└─┘╩ ╩┴  ┴         ");
            Console.WriteLine("                             ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }
        private static void ShowAllCountryNames()
        {
            var showCountries = dataAccess.GetAllCountriesToList();

			foreach (var item in showCountries)
			{
				Console.WriteLine(" " + item.Name + " ");
			}

		}

		private static void ShowAllCountriesInfo()
		{
			var showInfo = dataAccess.GetAllCountryInfo();
            ShowAppLogo();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("\n" + " CONTINENT".PadRight(27) + "COUNTRY".PadRight(27) + "CAPTITAL".PadRight(27) + "CLIMATE".PadRight(27) + "LANGUAGE".PadRight(27) + "TERRAIN".PadRight(27) + "RELIGION".PadRight(27));
			Console.ResetColor();

			foreach (var item in showInfo)
			{
				Console.WriteLine();
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine(" " + item.Continent.Name.PadRight(27) + item.Name.PadRight(27) + item.Capital.PadRight(27) + item.Climate.Name.PadRight(27) + item.LanguageInCountries.Select(x => x.Language.Name).FirstOrDefault().PadRight(27) + item.TerrainInCountries.Select(x => x.Terrain.Type).FirstOrDefault().ToString().PadRight(27) + item.ReligionInCountries.Select(x => x.Religion.Name).FirstOrDefault().PadRight(27));
				Console.ResetColor();
			}
            Console.WriteLine();
            Console.WriteLine(" Press any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();
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

		private static void RecreateDatabase()
		{
			dataAccess.RecreateDatabase();
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

            bool myBool = dataAccess.ValidateLanguage(language);

            while (myBool == false)
            {
                WriteInRed(" Are you sure you entered a valid id?");
                WriteInWhiteWithoutNewLine(" Please try again: ");
                language = int.Parse(Console.ReadLine());
                myBool = dataAccess.ValidateLanguage(language);
            }

            ShowAppLogo();
            WriteInWhite(" Countries with chosen language");

            foreach (var country in dataAccess.GetCountriesByLanguage(language))
            {
                Console.WriteLine(" " + country.Country.Name);
            }
            Console.WriteLine();
            Console.WriteLine(" Press any key to go back to all languages");
            Console.ReadKey();
            LanguageMenu();
        }


		private static void DisplayCountriesByReligion()
		{
			Console.WriteLine();
			Console.WriteLine();
			WriteInWhiteWithoutNewLine(" Enter the id of the religion do you wish to see more information about: ");
			var religion = int.Parse(Console.ReadLine());

			bool myBool = dataAccess.ValidateReligion(religion);

            while (myBool == false)
            {
                WriteInRed(" Are you sure you entered a valid id?");
                WriteInWhiteWithoutNewLine(" Please try again: ");
                religion = int.Parse(Console.ReadLine());
                myBool = dataAccess.ValidateReligion(religion);
            }

            ShowAppLogo();
            ReligionInfo(religion);
            Console.WriteLine();
            WriteInWhite(" Countries with chosen religion");
            foreach (var country in dataAccess.GetCountriesByReligion(religion))
            {
                Console.WriteLine(" " + country.Name);
            }
            Console.WriteLine();
            Console.WriteLine(" Press any key to go back to all religions");
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
