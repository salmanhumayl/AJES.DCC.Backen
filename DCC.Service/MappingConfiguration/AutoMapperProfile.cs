using AutoMapper;
using DCC.Model.Models;
using DCC.ModelSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.MappingConfiguration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DcconGoing, DcconGoingModel>().ReverseMap();
        }
    }
}
