using System;

namespace GeoApp
{
    class Program
    {
        private static DataAccess dataAccess = new DataAccess();

        static void Main(string[] args)
        {
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
            throw new NotImplementedException();
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
    }
}
