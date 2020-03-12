using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SmartAgri.DataBase.Communication.Helpers
{
    public static class GetConnectionString
    {
        private static readonly string _connString = "Server='database-1.cjsu9j876srn.eu-west-1.rds.amazonaws.com'; Port=5432; Database=SmartAgri;User Id=postgres;Password=734afuz6;";


        public static string GetConnString()
        {
            return _connString;
        }
    }
}
