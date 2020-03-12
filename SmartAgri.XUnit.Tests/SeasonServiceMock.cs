using SmartAgri.DataBase.Communication;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAgri.XUnit.Tests
{
    class SeasonServiceMock : ISeasonService
    {
        private readonly List<Season> _seasons= new List<Season>();

        public SeasonServiceMock()
        {
            _seasons.Add(new Season { Deleted = false, Id = 2019, Name = "2019" });
            _seasons.Add(new Season { Deleted = false, Id = 2020, Name = "2020" });
        }
        public bool DeleteSeason(int id)
        {
            Season season = _seasons.Find(x => x.Id == id);
            return _seasons.Remove(season);
        }

        public Season GetSeason(Season season)
        {
            return _seasons.Find(x => season.Id == x.Id);
        }

        public Season GetSeasonById(int id)
        {
            return _seasons.Find(x => id == x.Id);
        }

        public List<Season> GetSeasonByYear(int year)
        {
            return _seasons.Where(x => year == x.Id).ToList();
        }

        public List<Season> GetSeasons()
        {
            return _seasons;
        }

        public bool InsertSeason(Season season)
        {
            var count = _seasons.Count();
            _seasons.Add(season);
            return count < _seasons.Count();
        }
    }
}
