using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    public class GetHashAndSalt
    {
        public User Execute(string email)
        {
            User user = new User();
            try
            {

                using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                {
                    NpgsqlCommand cmd = conn.CreateCommand();

                    conn.Open();
                    cmd.Parameters.Add(new NpgsqlParameter("@email", email));
                    cmd.CommandText = "SELECT * from t_user WHERE email=@email LIMIT 1";

                    IDataReader rdr = cmd.ExecuteReader();
                    user = null;

                    while (rdr.Read())
                    {
                        User _user = new User(rdr);
                        user = _user;
                    }

                    conn.Close();

                }
                return user;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
