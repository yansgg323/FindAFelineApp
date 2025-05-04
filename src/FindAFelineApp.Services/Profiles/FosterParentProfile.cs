using AutoMapper;
using FindAFelineApp.Data.Entities;
using FindAFelineApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAFelineApp.Services.Profiles
{
    class FosterParentProfile : Profile
    {
        public FosterParentProfile()
        {
            CreateMap<FosterParent, AdopterDTO>()
                .ReverseMap();
        }
    }
}