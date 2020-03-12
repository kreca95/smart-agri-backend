using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication
{
    public class SeasonService : ISeasonService
    {
		public bool DeleteSeason(int  id)
		{
			try
			{
				Queries.DeleteSeason deleteSeason = new Queries.DeleteSeason();
				return deleteSeason.Execute(id);
			}
			catch (Exception e)
			{

				throw e;
			}
		}

		public Season GetSeason(Season season)
		{
			try
			{
				Queries.GetSeason getSeason = new Queries.GetSeason();
				return getSeason.Execute(season);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw;
			}
		}

		public Season GetSeasonById(int id)
        {
			try
			{
				Queries.GetSeasonById getSeasonByYear = new Queries.GetSeasonById();
				return getSeasonByYear.Execute(id);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw;
			}
        }

		public List<Season> GetSeasonByYear(int year)
		{
			try
			{
				Queries.GetFieldBySeasonYear getSeasonByYear = new Queries.GetFieldBySeasonYear();
				return getSeasonByYear.Execute(year);
			}
			catch (Exception e)
			{

				throw e;
			}
		}

		public List<Season> GetSeasons()
		{
			try
			{
				Queries.GetSeasons getSeasonByYear = new Queries.GetSeasons();
				return getSeasonByYear.Execute();
			}
			catch (Exception e)
			{

				throw e;
			}
		}

		public bool InsertSeason(Season season)
		{
			try
			{
				Queries.UpsertSeason insertSeason = new Queries.UpsertSeason();
				return insertSeason.Execute(season);
	}
			catch (Exception e)
			{

				throw e;
			}
		}
	}
}
