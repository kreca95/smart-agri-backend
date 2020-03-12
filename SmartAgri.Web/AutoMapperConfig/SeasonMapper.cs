using AutoMapper;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAgri.Web.AutoMapperConfig
{
    public class SeasonMapper : Profile
    {
        public SeasonMapper()
        {
            CreateMap<Season, Models.UpsertSeasonDTO>().ReverseMap();
            //CreateMap<Models.UpsertSeasonDTO, Season>();

            //CreateMap<Season, Models.GetSeasonDTO>();
            CreateMap<Models.GetSeasonDTO, Season>().ReverseMap();
        }
    }
}
