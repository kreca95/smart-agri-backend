using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    public class GetAllUsers
    {
        internal List<User> Execute()
        {
            List<User> users= new List<User>();
            try
            {
                int br = 0;
                using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                {
                    NpgsqlCommand cmd = conn.CreateCommand();

                    conn.Open();

                    cmd.CommandText = "SELECT * FROM users";

                    IDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        User user = new User(rdr);
                        users.Add(user);
                    }
                    conn.Close();

                }
                return users;
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
    }
}
