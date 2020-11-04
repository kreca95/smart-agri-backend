using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    public class GetSeason
    {
        internal Season Execute(Season season)
        {
            try
            {
                int br = 0;
                using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                {
                    NpgsqlCommand cmd = conn.CreateCommand();

                    conn.Open();
                    cmd.Parameters.Add(new NpgsqlParameter("@id", season.Id));
                    cmd.Parameters.Add(new NpgsqlParameter("@name", season.Name));

                    cmd.CommandText = "SELECT * FROM t_agri_season as s WHERE s.id=@id and s.name=@name and s.delted is not true";

                    IDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Season _season = new Season(rdr);
                        season = _season;
                    }
                    try
                    {
                        br = cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {

                        throw e;
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
