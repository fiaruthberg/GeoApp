using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoApp
{
    public class DataAccess
    {
        private readonly GeoContext context;
        public DataAccess()
        {
            context = new GeoContext();
        }
        internal void ClearDatabase()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

        }

        internal void SaveChanges()
        {
            context.SaveChanges();
        }

        public List<Country> GetAllCountriesToList()
        {
            return context.Countries.ToList();
        }

        public List<Country> GetAllCountriesToListWithLetter(char input)
        {
            return context.Countries.Where(x => x.Name.StartsWith(input)).ToList();
        }

        public List<Country> GetCountriesByReligion(string religion)
        {
            List<Country> newList = new List<Country>();

            foreach (var religionInCountry in context.ReligionsInCountry.Where(x => x.Religion.Name == religion))
            {
                newList.Add(religionInCountry.Country);
            }
            return newList;
        }
        public List<Country> GetCountriesByReligion(int religionId)
        {
            List<Country> newList = new List<Country>();

            foreach (var religionInCountry in context.ReligionsInCountry.Where(x => x.ReligionId == religionId))
            {
                newList.Add(religionInCountry.Country);
            }
            return newList;
        }

        public List<LanguageInCountry> GetCountriesByLanguage(int languageId)
        {

            return context.LanguagesInCoyntry.Where(x => x.LanguageId == languageId).ToList();

        }
        public List<Country> GetCountriesByTerrain(string type)
        {
            TerrainType a = Enum.Parse<TerrainType>(type);
            List<Country> newList = new List<Country>();

            foreach (var item in context.TerrainInCountries.Where(x => x.Terrain.Type == a))
            {
                newList.Add(item.Country);
            }
            return newList;
        }
        public List<Country> GetCountriesByClimate(int climateId)
        {
            var newList = new List<Country>();

            foreach (var item in context.Countries.Where(x => x.Climate.Id == climateId))
            {
                newList.Add(item);
            }
            return newList;
        }

        public List<Religion> GetAllReligions()
        {
            return context.Religions.ToList();
        }

        public List<Language> GetAllLanguages()
        {
            return context.Languages.ToList();
        }

        public void PopulateSimpleTables()
        {
            var europa = new Continent { Name = "Europe" };
            var africa = new Continent { Name = "Africa" };
            var asia = new Continent { Name = "Asia" };
            var northAmerica = new Continent { Name = "North America" };
            var southAmerica = new Continent { Name = "South America" };
            var oceania = new Continent { Name = "Oceania" };

            var monarchy = new GovernmentPolity { Polity = Polity.Monarchy };
            var republic = new GovernmentPolity { Polity = Polity.Republic };

            var polityList = new List<GovernmentPolity>
            {
                monarchy,
                republic
            };
            context.GovernmentPolities.AddRange(polityList);

            var arctic = new Climate { Name = "Arctic" };
            var tropical = new Climate { Name = "Tropical" };
            var subTropical = new Climate { Name = "Sub-Tropical" };
            var temperate = new Climate { Name = "Temperate" };

            var christianity = new Religion { Name = "Christianity" };
            var islam = new Religion { Name = "Islam" };
            var hinduism = new Religion { Name = "Hinduism" };
            var buddhism = new Religion { Name = "Buddhism" };
            var judaism = new Religion { Name = "Judaism" };

            context.Religions.AddRange(christianity, islam, hinduism, buddhism, judaism);

            var desert = new Terrain { Type = TerrainType.Desert };
            var forest = new Terrain { Type = TerrainType.Forest };
            var plains = new Terrain { Type = TerrainType.Plains };
            var mountains = new Terrain { Type = TerrainType.Mountain };
            var rainForest = new Terrain { Type = TerrainType.rainForest };

            context.Terrains.AddRange(desert, forest, plains, mountains);

            var swedish = new Language { Name = "Swedish" };
            var english = new Language { Name = "English" };
            var spanish = new Language { Name = "Spanish" };
            var arabic = new Language { Name = "Arabic" };
            var sinhala = new Language { Name = "Sinhala" };
            var swahili = new Language { Name = "Swahili" };
            var creole = new Language { Name = "Creole" };
            var hiriMotu = new Language { Name = "Hiri Motu" };
            var russian = new Language { Name = "Russian" };

            context.Languages.AddRange(swedish, english);

            var countryList = new List<Country>
            {
                new Country { Name = "Sweden", Capital = "Stockholm", Climate = temperate, Continent = europa, GovernmentPolity = monarchy,
                    Regions = new List<Region> { new Region { Name = "Svealand" }, new Region { Name = "Götaland" }, new Region { Name = "Norrland" } },
                    LanguageInCountries = new List<LanguageInCountry> { new LanguageInCountry { Language = swedish } },
                    ReligionInCountries = new List<ReligionInCountry> { new ReligionInCountry { Religion = christianity } },
                    TerrainInCountries = new List<TerrainInCountry> {new TerrainInCountry { Terrain = forest } } },

                  new Country { Name = "Panama", Capital = "Panama City", Climate = tropical, Continent = southAmerica, GovernmentPolity = republic,
                    Regions = new List<Region> { new Region { Name = "North" }, new Region { Name = "Middle" }, new Region { Name = "South" } },
                    LanguageInCountries = new List<LanguageInCountry> { new LanguageInCountry { Language = spanish  } },
                    ReligionInCountries = new List<ReligionInCountry> { new ReligionInCountry { Religion = christianity } },
                    TerrainInCountries = new List<TerrainInCountry> {new TerrainInCountry { Terrain = rainForest } } },

                   new Country { Name = "Oman", Capital = "Muskat", Climate = tropical, Continent = asia, GovernmentPolity = monarchy,
                    Regions = new List<Region> { new Region { Name = "Upper Oman" }, new Region { Name = "Middle Oman" }, new Region { Name = "Lower Oman" } },
                    LanguageInCountries = new List<LanguageInCountry> { new LanguageInCountry { Language = spanish  } },
                    ReligionInCountries = new List<ReligionInCountry> { new ReligionInCountry { Religion = islam } },
                    TerrainInCountries = new List<TerrainInCountry> {new TerrainInCountry { Terrain = desert } } },

                   new Country { Name = "Liberia", Capital = "Monrovia", Climate = tropical, Continent = africa, GovernmentPolity = republic,
                    Regions = new List<Region> { new Region { Name = "North" }, new Region { Name = "Middle" }, new Region { Name = "South" } },
                    LanguageInCountries = new List<LanguageInCountry> { new LanguageInCountry { Language = english  } },
                    ReligionInCountries = new List<ReligionInCountry> { new ReligionInCountry { Religion = christianity } },
                    TerrainInCountries = new List<TerrainInCountry> {new TerrainInCountry { Terrain = desert } } },

                   new Country { Name = "Sri Lanka", Capital = "Sri Jayawardenapura", Climate = tropical, Continent = asia, GovernmentPolity = republic,
                    Regions = new List<Region> { new Region { Name = "North" }, new Region { Name = "Middle" }, new Region { Name = "South" } },
                    LanguageInCountries = new List<LanguageInCountry> { new LanguageInCountry { Language = sinhala  } },
                    ReligionInCountries = new List<ReligionInCountry> { new ReligionInCountry { Religion = buddhism } },
                    TerrainInCountries = new List<TerrainInCountry> {new TerrainInCountry { Terrain = forest } } },

                      new Country { Name = "Mexico", Capital = "Mexico City", Climate = subTropical, Continent = northAmerica, GovernmentPolity = republic,
                    Regions = new List<Region> { new Region { Name = "North" }, new Region { Name = "Middle" }, new Region { Name = "South" } },
                    LanguageInCountries = new List<LanguageInCountry> { new LanguageInCountry { Language = spanish  } },
                    ReligionInCountries = new List<ReligionInCountry> { new ReligionInCountry { Religion = christianity} },
                    TerrainInCountries = new List<TerrainInCountry> {new TerrainInCountry { Terrain = plains } } },


                      new Country { Name = "Tanzania", Capital = "Dodoma", Climate = tropical, Continent = africa, GovernmentPolity = republic,
                    Regions = new List<Region> { new Region { Name = "North" }, new Region { Name = "Middle" }, new Region { Name = "South" } },
                    LanguageInCountries = new List<LanguageInCountry> { new LanguageInCountry { Language = swahili  } },
                    ReligionInCountries = new List<ReligionInCountry> { new ReligionInCountry { Religion = christianity} },
                    TerrainInCountries = new List<TerrainInCountry> {new TerrainInCountry { Terrain = mountains } } },

                        new Country { Name = "Bahamas", Capital = "Nassau", Climate = tropical, Continent = northAmerica, GovernmentPolity = republic,
                    Regions = new List<Region> { new Region { Name = "North" }, new Region { Name = "Middle" }, new Region { Name = "South" } },
                    LanguageInCountries = new List<LanguageInCountry> { new LanguageInCountry { Language = creole  } },
                    ReligionInCountries = new List<ReligionInCountry> { new ReligionInCountry { Religion = christianity} },
                    TerrainInCountries = new List<TerrainInCountry> {new TerrainInCountry { Terrain = plains } } },

                        new Country { Name = "Papua New Guinea", Capital = "Port Moresby", Climate = tropical, Continent = oceania, GovernmentPolity = republic,
                    Regions = new List<Region> { new Region { Name = "North" }, new Region { Name = "Middle" }, new Region { Name = "South" } },
                    LanguageInCountries = new List<LanguageInCountry> { new LanguageInCountry { Language = hiriMotu  } },
                    ReligionInCountries = new List<ReligionInCountry> { new ReligionInCountry { Religion = christianity} },
                    TerrainInCountries = new List<TerrainInCountry> {new TerrainInCountry { Terrain = plains } } },

                        new Country { Name = "Moldova", Capital = "Chisinau", Climate = temperate, Continent = europa, GovernmentPolity = republic,
                    Regions = new List<Region> { new Region { Name = "North" }, new Region { Name = "Middle" }, new Region { Name = "South" } },
                    LanguageInCountries = new List<LanguageInCountry> { new LanguageInCountry { Language = russian  } },
                    ReligionInCountries = new List<ReligionInCountry> { new ReligionInCountry { Religion = christianity} },
                    TerrainInCountries = new List<TerrainInCountry> {new TerrainInCountry { Terrain = forest } } }





            };
            context.AddRange(countryList);
            context.SaveChanges();
        }

		public List<Country> GetAllCountryInfo()
		{
			return context.Countries
                .Include(x=>x.Continent)
                .Include(x => x.Climate)
                .Include(x => x.LanguageInCountries)
                .ThenInclude(x => x.Language)
                .Include(x => x.TerrainInCountries)
                .ThenInclude(x => x.Terrain)
                .Include(x => x.ReligionInCountries)
                .ThenInclude(x => x.Religion)
                .ToList();
		}

		internal bool ValidateTerrain(int terrainId)
        {
            if (!context.Terrains.Select(x => x.Id).Contains(terrainId))
            {
                return false;
            }
            return true;
        }

        internal List<Country> GetCountriesByContinent(int continentId)
        {
            var newList = new List<Country>();

            foreach (var item in context.Countries.Where(x => x.Continent.Id == continentId))
            {
                newList.Add(item);
            }
            return newList;
        }
        internal List<Country> GetCountriesByTerrain(int terrainId)
        {
            var newList = new List<Country>();

            foreach (var item in context.TerrainInCountries.Where(x => x.Terrain.Id == terrainId))
            {
                newList.Add(item.Country);
            }
            return newList;
        }
        internal List<Climate> GetAllClimates()
        {
            return context.Climates.ToList();
        }
        internal List<Continent> GetAllContinents()
        {
            return context.Continents.ToList();
        }
        internal List<Terrain> GetAllTerrains()
        {
            return context.Terrains.ToList();
        }
        internal bool ValidateReligion(int religion)
        {
            if (!context.Religions.Select(x => x.Id).Contains(religion))
            {
                return false;
            }
            return true;
        }
        internal bool ValidateContinent(int continentId)
        {
            if (!context.Continents.Select(x => x.Id).Contains(continentId))
            {
                return false;
            }
            return true;
        }
        internal bool ValidateClimate(int climateId)
        {
            if (!context.Climates.Select(x => x.Id).Contains(climateId))
            {
                return false;
            }
            return true;
        }
        internal bool ValidateLanguage(int languageId)
        {
            if (!context.Languages.Select(x => x.Id).Contains(languageId))
            {
                return false;
            }
            return true;
        }
    }
}
