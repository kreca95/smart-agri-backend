using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    public class InsertAgriCropSpec
    {
        internal bool Execute(AgriCropSpec agriCropSpec)
        {
            try
            {
                int br = 0;
                if (agriCropSpec != null)
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                    {
                        NpgsqlCommand cmd = conn.CreateCommand();

                        conn.Open();

                        cmd.Parameters.Add(new NpgsqlParameter("@sort", agriCropSpec.CropSort));
                        cmd.Parameters.Add(new NpgsqlParameter("@type", agriCropSpec.CropType));


                        cmd.CommandText = @"INSERT INTO t_agri_crop_specs (crop_type_name,crop_sort_name) VALUES (@type,@sort)";

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
