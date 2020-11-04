using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    public class DeleteAgriCropSpec
    {
        internal bool Execute(int id)
        {
            List<User> users = new List<User>();
            try
            {
                int br = 0;
                using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                {
                    NpgsqlCommand cmd = conn.CreateCommand();

                    conn.Open();
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.CommandText = "DELETE FROM t_agri_crop_specs WHERE id=@id";

                    br = cmd.ExecuteNonQuery();


                    conn.Close();

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
