using SmartAgri.DataBase.Communication.Interfaces;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication.ServicesImplementations
{
    public class FieldService : IFieldService
    {
		private readonly NLog.Logger _logger;
		public FieldService()
		{
			_logger = new NLogDb.NLogDB().GetLogger();
		}

		public string GetFieldsBySeasonYear(int year)
		{
			try
			{
				Queries.GetFieldsBySeasonYear getFieldBySeasonYear = new Queries.GetFieldsBySeasonYear();
				return getFieldBySeasonYear.Execute(year);
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

		public bool UpsertField(Field field)
        {
			try
			{
				Queries.UpsertField insertField = new Queries.UpsertField();
				return insertField.Execute(field);
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
