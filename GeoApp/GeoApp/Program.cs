using System;

namespace GeoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ClearDatabase();
            InitDatabase();
        }

        private static void ClearDatabase()
        {
            var dataAccess = new DataAccess();
            dataAccess.ClearDatabase();

        }

        private static void InitDatabase()
        {
            throw new NotImplementedException();
        }
    }
}
