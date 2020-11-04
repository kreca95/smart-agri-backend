using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    public class UpdateAgriCropSpec
    {
        public bool Execute(AgriCropSpec agriCropSpec)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                {
                    conn.Open();

                    NpgsqlCommand command = conn.CreateCommand();
                    command.Parameters.Add(new NpgsqlParameter("@id", agriCropSpec.Id));
                    command.Parameters.Add(new NpgsqlParameter("@sort", agriCropSpec.CropSort));
                    command.Parameters.Add(new NpgsqlParameter("@type", agriCropSpec.CropType));

                    command.CommandText = string.Format("UPDATE t_agri_crop_specs SET crop_sort_name=@sort,crop_type_name=@type where id=@id");
                    int br = 0;
                    try
                    {
                        br = command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        //return false;
                        throw e;
                    }

                    return true;
                }


            }
            catch (Exception e)
            {
                //return false;

                throw e;
            }
        }
    }
}
