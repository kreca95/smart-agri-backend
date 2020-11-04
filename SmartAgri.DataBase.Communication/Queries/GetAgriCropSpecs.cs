using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    public class GetAgriCropSpecs
    {
        internal List<AgriCropSpec> Execute()
        {
            try
            {
                List<AgriCropSpec> agriCropSpecs = new List<AgriCropSpec>();
                int br = 0;
                using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                {
                    NpgsqlCommand cmd = conn.CreateCommand();

                    conn.Open();

                    cmd.CommandText = "SELECT * FROM t_agri_crop_specs";
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AgriCropSpec agriCropSpec = new AgriCropSpec();
                        agriCropSpec.Id = reader.GetRecord<int>("id");
                        agriCropSpec.CropSort = reader.GetRecord<string>("crop_sort_name");
                        agriCropSpec.CropType = reader.GetRecord<string>("crop_type_name");
                        agriCropSpecs.Add(agriCropSpec);
                    }


                    conn.Close();

                }
                return agriCropSpecs;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
