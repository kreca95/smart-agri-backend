using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    public class GetAgriCropSpec
    {
        internal AgriCropSpec Execute(int id)
        {
            try
            {
                AgriCropSpec agriCropSpec = new AgriCropSpec();
                int br = 0;
                using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                {
                    NpgsqlCommand cmd = conn.CreateCommand();

                    conn.Open();
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));

                    cmd.CommandText = "SELECT * FROM t_agri_crop_specs as s WHERE s.id=@id ";
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        agriCropSpec.Id = reader.GetRecord<int>("id");
                        agriCropSpec.CropSort = reader.GetRecord<string>("crop_sort_name");
                        agriCropSpec.CropType = reader.GetRecord<string>("crop_type_name");
                    }


                    conn.Close();

                }
                return agriCropSpec;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
