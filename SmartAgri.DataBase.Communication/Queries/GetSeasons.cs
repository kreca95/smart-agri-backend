using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    class GetSeasons
    {
        public List<Season> Execute( )
        {
            List<Season> seasons = new List<Season>();
            try
            {

                using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                {
                    NpgsqlCommand cmd = conn.CreateCommand();

                    conn.Open();
                    cmd.CommandText = "SELECT * from season as s  where s.deleted is not true";

                    IDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Season _season = new Season(rdr);
                        seasons.Add(_season);
                    }

                    conn.Close();

                }
                return seasons;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
