using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    public class InsertUser
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
                        cmd.Parameters.Add(new NpgsqlParameter("@firstname", user.FirstName));
                        cmd.Parameters.Add(new NpgsqlParameter("@lastname", user.LastName));
                        cmd.Parameters.Add(new NpgsqlParameter("@role", user.RoleId=3));
                        cmd.Parameters.Add(new NpgsqlParameter("@sex", user.Sex));
                        cmd.Parameters.Add(new NpgsqlParameter("@birthday", user.Birthday));
                        cmd.Parameters.Add(new NpgsqlParameter("@email", user.Email));
                        cmd.Parameters.Add(new NpgsqlParameter("@passwordhash", user.PasswordHash));
                        cmd.Parameters.Add(new NpgsqlParameter("@passwordsalt", user.PasswordSalt));

                        cmd.CommandText = @"INSERT INTO users (first_name,last_name,role,sex,birthday,email,passwordhash,passwordsalt) 
                                            VALUES (@firstname,@lastname,@role,@sex,@birthday,@email,@passwordhash,@passwordsalt)
                                            ON CONFLICT(email) DO NOTHING
                                            ";                                            

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
