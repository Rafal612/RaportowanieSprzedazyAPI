using AutoMapper;
using RaportowanieSprzedazy.DTO;
using RaportowanieSprzedazy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaportowanieSprzedazy.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Projekt, ProjektDto>();
            CreateMap<ProjektDto, Projekt>();

        }
    }
}