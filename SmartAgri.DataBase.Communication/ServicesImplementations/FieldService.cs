using SmartAgri.DataBase.Communication.Interfaces;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication.ServicesImplementations
{
    public class FieldService : IFieldService
    {
		public string GetFieldsBySeasonYear(int year)
		{
			try
			{
				Queries.GetFieldsBySeasonYear getFieldBySeasonYear = new Queries.GetFieldsBySeasonYear();
				return getFieldBySeasonYear.Execute(year);
			}
			catch (Exception e)
			{

				throw e;
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

				throw e;
			}
        }
    }
}
