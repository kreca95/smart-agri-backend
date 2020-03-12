using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication.Interfaces
{
    public interface IFieldService
    {
        bool UpsertField(Field field);
        string GetFieldsBySeasonYear(int year);

    }
}
