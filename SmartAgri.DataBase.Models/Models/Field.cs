using SmartAgri.DataBase.Models.Models.Geom;
namespace SmartAgri.DataBase.Models.Models
{
    public class Field
    {
        public int Id { get; set; }
        public string Geom { get; set; }
        public string Name { get; set; }
        public string NasIme { get; set; }
        public int SeasonId { get; set; }
        public string FieldId { get; set; }

        public GeomNas Geom_ { get; set; }

        public Season Season { get; set; }

        public Field()
        {
            Season = new Season();
            Geom_ = new GeomNas();
        }
    }
}
