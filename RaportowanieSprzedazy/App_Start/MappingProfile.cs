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

            CreateMap<Pracownik, PracownikDto>();
            CreateMap<PracownikDto, Pracownik>();

            CreateMap<Ankieta,AnkietaDto>();
            CreateMap<AnkietaDto, Ankieta>();

            CreateMap<Pytanie, PytanieDto>();
            CreateMap<PytanieDto, Pytanie>();

        }
    }
}