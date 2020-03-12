using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication
{
    public interface ISeasonService
    {
        Season GetSeasonById(int id);
        List<Season> GetSeasonByYear(int year);
        List<Season> GetSeasons();
        bool InsertSeason(Season season);
        Season GetSeason(Season season);
        bool DeleteSeason(int id);
    }
}
