using AutoMapper;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAgri.Web.AutoMapperConfig
{
    public class FieldMapperConfig:Profile
    {
        //testirat reverse mapp
        public FieldMapperConfig()
        {
            CreateMap<Field, Models.UpsertFieldDTO>()
                .ForMember(dest => dest.SeasonId, opt => opt.MapFrom(src => src.Season.Id)).ReverseMap();

            //CreateMap<Models.UpsertFieldDTO, Field>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SeasonId)); ;

        }
    }
}
