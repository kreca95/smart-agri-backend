using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    class DeleteSeason
    {
        public bool Execute(int id)
        {
            try
            {

                using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                {
                    NpgsqlCommand cmd = conn.CreateCommand();

                    conn.Open();
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.CommandText = "UPDATE season set deleted=true WHERE id=@id";
                    int br = 0;
                    try
                    {
                         br = cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }

                    conn.Close();

                    return br > 0;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
