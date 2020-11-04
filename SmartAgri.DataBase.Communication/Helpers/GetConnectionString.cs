using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SmartAgri.DataBase.Communication.Helpers
{
    public static class GetConnectionString
    {
        private static readonly string _connString = "Server='smart-agri1.cefouru8azlr.eu-central-1.rds.amazonaws.com'; Port=5432; Database=postgres;User Id=postgres;Password=nWMGnHR6m5kWuWDcYSKw;";


        public static string GetConnString()
        {
            return _connString;
        }
    }
}
