using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    public class UpsertField
    {
        internal bool Execute(Field field)
        {
            try
            {
                //upitno
                var json = JsonConvert.SerializeObject(field.Geom_.features.FirstOrDefault().geometry);
                int br = 0;
                if (field != null)
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                    {
                        NpgsqlCommand cmd = conn.CreateCommand();
                        conn.Open();
                        cmd.Parameters.Add(new NpgsqlParameter("@geom", json));
                        cmd.Parameters.Add(new NpgsqlParameter("@name", field.Name));
                        cmd.Parameters.Add(new NpgsqlParameter("@nas_ime", field.NasIme));
                        cmd.Parameters.Add(new NpgsqlParameter("@season_id", field.Season.Id));
                        cmd.Parameters.Add(new NpgsqlParameter("@field_id", field.FieldId));
                        cmd.Parameters.Add(new NpgsqlParameter("@id", field.Id));
                        cmd.CommandText = @"INSERT INTO fields (geom, name, nas_ime, season_id, field_id)
                                            VALUES (ST_Transform(ST_SetSRID(ST_GeomFromGeoJSON(@geom),4326),32633),@name,@nas_ime,@season_id,@field_id)
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
                //ST_Transform(ST_SetSRID(ST_GeomFromGeoJSON('{"t8548]]]}'), 4326), 32633)
                throw e;
            }
        }
    }
}

