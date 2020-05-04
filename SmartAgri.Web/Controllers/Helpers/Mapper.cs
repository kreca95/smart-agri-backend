using SmartAgri.DataBase.Models.Models;
using SmartAgri.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAgri.Web.Controllers.Helpers
{
    public class Mapper
    {
        public static User MappUserDTOToUser(RegisterUserDTO userDTO)
        {
            User user = new User
            {
                Birthday = userDTO.Birthday,
                Email = userDTO.Email,
                PasswordSalt = Salt.Create(),
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Sex = userDTO.Sex,
            };
            user.PasswordHash = Hash.Create(userDTO.Password, user.PasswordSalt);

            return user;
        }
        public static List<GetSeasonDTO> MappGetSeasonDTO(List<Season> seasons)
        {
            List<GetSeasonDTO> _seasons = new List<GetSeasonDTO>();
            foreach (var item in seasons)
            {
                _seasons.Add(new GetSeasonDTO { Id = item.Id, Name = item.Name });
            }
            return _seasons;
        }


        public static Season MappSeasonFromUpsertSeasonDTO(UpsertSeasonDTO season)
        {
            Season season1 = new Season();
            season1.Id = season.Id;
            season1.Name = season.Name;
            return season1;
        }

        public static Field MappField(UpsertFieldDTO field)
        {
            Field field1 = new Field();

            field1.FieldId = field.FieldId;
            field1.Geom_ = field.Geom;
            field1.Id = field.Id;
            field1.Name = field.Name;
            field1.NasIme = field.NasIme;
            field1.SeasonId = field.SeasonId;

            return field1;
        }
    }
}
