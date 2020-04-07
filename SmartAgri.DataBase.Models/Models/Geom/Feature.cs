namespace SmartAgri.DataBase.Models.Models.Geom
{
    public class Feature
    {
        public string type { get; set; }
        public PropertiesNas properties { get; set; }
        public Geometry geometry { get; set; }
    }
}