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
		public DbSet<Religion> Religions { get; set; }
		public DbSet<ReligionInCountry> ReligionsInCountry { get; set; }
		public DbSet<TerrainInCountry> TerrainInCountries { get; set; }
	    public DbSet<Terrain> Terrains { get; set; }
		public DbSet<Language> Languages { get; set; }
		public DbSet<LanguageInCountry> LanguagesInCoyntry { get; set; }
		public DbSet<GovernmentPolity> GovernmentPolities { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
			  "Server = (localdb)\\mssqllocaldb; Database = GeoApp;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ReligionInCountry>().HasKey(x => new { x.ReligionId, x.CountryId });
            modelBuilder.Entity<TerrainInCountry>().HasKey(x => new { x.TerrainId, x.CountryId });
            modelBuilder.Entity<LanguageInCountry>().HasKey(x => new { x.LanguageId, x.CountryId });
        }
	}
}
