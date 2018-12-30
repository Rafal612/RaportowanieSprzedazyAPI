using AutoMapper;
using RaportowanieSprzedazy.DTO;
using RaportowanieSprzedazy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RaportowanieSprzedazy.Controllers.API
{
    public class ProjektController : ApiController
    {
        private RaportowanieSprzedazyContext _context;

        //GET /api/projekty
        public IEnumerable<ProjektDto> GetProjekty()
        {
            return _context.Projekty.ToList().Select(Mapper.Map<Projekt, ProjektDto>);
        }

        // GET /api/projekty/1
        public ProjektDto GetProjekt(int id)
        {
            Projekt projekt = _context.Projekty.Where(w => w.Id == id).SingleOrDefault();

            if (projekt == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Projekt, ProjektDto>(projekt);
        }

        // POST /api/projekty
        [HttpPost]
        public ProjektDto PostProjekt(ProjektDto projektDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Projekt projekt = Mapper.Map<ProjektDto, Projekt>(projektDto);

            _context.Projekty.Add(projekt);
            _context.SaveChanges();

            projektDto.Id = projekt.Id;

            return projektDto;
        }



    }
}
