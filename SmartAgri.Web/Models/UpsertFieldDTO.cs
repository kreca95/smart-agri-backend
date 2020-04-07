using SmartAgri.DataBase.Models.Models.Geom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAgri.Web.Models
{
    public class UpsertFieldDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public GeomNas Geom { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NasIme { get; set; }
        [Required]
        public int SeasonId { get; set; }
        [Required]
        public string FieldId { get; set; }


    }
}
