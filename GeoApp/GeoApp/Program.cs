using System;

namespace GeoApp
{
    class Program
    {
        private static DataAccess dataAccess = new DataAccess();

        static void Main(string[] args)
        {
            ClearDatabase();
            InitDatabase();
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
