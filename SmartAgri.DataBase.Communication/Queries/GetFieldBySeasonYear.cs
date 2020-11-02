using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    public class GetFieldBySeasonYear
    {
        public List<Season> Execute(int year)
        {
            List<Season> seasons = new List<Season>();
            try
            {
                //ispravak
                using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                {
                    NpgsqlCommand cmd = conn.CreateCommand();

                    conn.Open();
                    cmd.Parameters.Add(new NpgsqlParameter("@year", year));
                    cmd.CommandText = "SELECT * from fields WHERE season_id=@year";

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
