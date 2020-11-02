using Npgsql;
using SmartAgri.DataBase.Communication.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartAgri.DataBase.Communication.Queries
{
    class GetFieldsBySeasonYear
    {
        public string Execute(int year)
        {
            
            try
            {
                string fields = string.Empty;

                using (NpgsqlConnection conn = new NpgsqlConnection(GetConnectionString.GetConnString()))
                {
                    NpgsqlCommand cmd = conn.CreateCommand();

                    conn.Open();
                    cmd.Parameters.Add(new NpgsqlParameter("@year", year));

                    cmd.CommandText = @"SELECT json_build_object(
                            'type', 'FeatureCollection',
                            'crs',  json_build_object(
                                'type',      'name', 
                                'properties', json_build_object(
                                    'name', 'EPSG:32633'  
                                )
                            ), 
                            'features', json_agg(
                                json_build_object(
                                    'type',       'Feature',
                                    'id',        id, -- the GeoJson spec includes an 'id' field, but it is optional, replace {id} with your id field
                                    'geometry',   ST_AsGeoJSON(geom)::json,
                                    'properties', json_build_object(
                                        -- list of fields
                                        'name', name,
                                        'nas_ime', nas_ime,
	                            'season_id', season_id,
	                            'field_id', field_id
                                    )
                                )
                            )
                        )
                        FROM t_agri_field
                        WHERE fields.season_id = @year;
                        ";

                    try
                    {
                        fields = cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }
                    conn.Close();

                }
                return fields;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
