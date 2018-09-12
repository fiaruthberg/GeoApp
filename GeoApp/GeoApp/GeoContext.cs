using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApp
{
    class GeoContext : DbContext
    {
		public DbSet<Country> Countries { get; set; }
		public DbSet<Continent> Continents { get; set; }
		public DbSet<Region> Regions { get; set; }
	
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
			  "Server = (localdb)\\mssqllocaldb; Database = GeoApp;");
		}
	}
}
