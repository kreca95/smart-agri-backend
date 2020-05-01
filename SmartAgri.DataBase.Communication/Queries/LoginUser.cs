using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    public class LoginUser
    {
        internal bool Execute(User user)
        {
            try
            {
                int br = 0;
                if (user != null)
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                    {
                        NpgsqlCommand cmd = conn.CreateCommand();

                        conn.Open();
                        
                        cmd.Parameters.Add(new NpgsqlParameter("@passwordhash", user.PasswordHash));
                        cmd.Parameters.Add(new NpgsqlParameter("@passwordsalt", user.PasswordSalt));

                        cmd.CommandText = @"";

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
