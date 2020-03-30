using NLog;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication
{
    public class SeasonService : ISeasonService
    {
        private readonly NLog.Logger _logger;
        public SeasonService()
        {
            _logger = new NLogDb.NLogDB().GetLogger();
        }

        public bool DeleteSeason(int id)
        {
            try
            {
                Queries.DeleteSeason deleteSeason = new Queries.DeleteSeason();
                return deleteSeason.Execute(id);
            }
            catch (Exception e)
            {
                _logger.Error("Method called: {0}, Error message: {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                throw e;
            }
            finally
            {
                _logger.Info("Method called: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                _logger.Error("Method called: {0}, Error message: {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                throw;
            }
            finally
            {
                _logger.Info("Method called: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                _logger.Error("Method called: {0}, Error message: {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                throw;
            }
            finally
            {
                _logger.Info("Method called: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                _logger.Error("Method called: {0}, Error message: {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                throw e;
            }
            finally
            {
                _logger.Info("Method called: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                _logger.Error("Method called: {0}, Error message: {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                throw e;
            }
            finally
            {
                _logger.Info("Method called: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                _logger.Error("Method called: {0}, Error message: {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                throw e;
            }
            finally
            {
                _logger.Info("Method called: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}
