﻿namespace SmartAgri.DataBase.Models.Models.Geom
{
    public class GeomNas
    {
        public string type { get; set; }
        public string name { get; set; }
        public Crs crs { get; set; }
        public Feature[] features { get; set; }
    }
}