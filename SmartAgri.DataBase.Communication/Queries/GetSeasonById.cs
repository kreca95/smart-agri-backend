using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    public class GetSeasonById
    {
        public Season Execute(int id)
        {
            Season season = new Season();
            try
            {

                using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                {
                    NpgsqlCommand cmd = conn.CreateCommand();

                    conn.Open();
                    cmd.Parameters.Add(new NpgsqlParameter("@year", id));
                    cmd.CommandText = "SELECT * from season WHERE id=@year and deleted is not true";

                    IDataReader rdr = cmd.ExecuteReader();
                    season = null;
                    while (rdr.Read())
                    {
                        Season _season = new Season(rdr);
                        season = _season;
                    }

                    conn.Close();

                }
                return season;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
