using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAgri.Web.Models
{
    public class UpsertSeasonDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Naziv ne može biti duži od 50 karaktera"),MinLength(3)]
        public string Name { get; set; }
    }
}
