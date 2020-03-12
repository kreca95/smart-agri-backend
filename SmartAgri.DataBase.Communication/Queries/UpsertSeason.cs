using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    public class UpsertSeason
    {
        internal bool Execute(Season season)
        {
            try
            {
                int br = 0;
                if (season != null)
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                    {
                        NpgsqlCommand cmd = conn.CreateCommand();

                        conn.Open();
                        cmd.Parameters.Add(new NpgsqlParameter("@id", season.Id));
                        cmd.Parameters.Add(new NpgsqlParameter("@name", season.Name));
                        cmd.Parameters.Add(new NpgsqlParameter("@deleted", season.Deleted));
                        cmd.CommandText = @"INSERT INTO season (id,name,deleted) 
                                            VALUES (@id,@name,false)
                                            ON CONFLICT(id) 
                                            DO
                                                UPDATE
                                                SET name = @name";

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
                }
                return br > 0;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
