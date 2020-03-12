using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAgri.Web.Models
{
    public class UpsertSeasonDTO
    {
        [Required(AllowEmptyStrings =false,ErrorMessage = "Id nije unešen)")]
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Naziv ne može biti duži od 50 karaktera")]
        public string Name { get; set; }
    }
}
