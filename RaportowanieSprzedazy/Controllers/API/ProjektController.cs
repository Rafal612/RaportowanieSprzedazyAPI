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

        public ProjektController()
        {
            _context = new RaportowanieSprzedazyContext();
        }

        //GET /api/projekty
        public IHttpActionResult GetProjekty()
        {
            return Ok(_context.Projekty.ToList().Select(Mapper.Map<Projekt, ProjektDto>));
        }

        // GET /api/projekty/1
        public IHttpActionResult GetProjekt(int id)
        {
            Projekt projekt = _context.Projekty.Where(w => w.Id == id).SingleOrDefault();

            if (projekt == null)
                return NotFound();

            return  Ok(Mapper.Map<Projekt, ProjektDto>(projekt));
        }

        // POST /api/projekty
        [HttpPost]
        public IHttpActionResult PostProjekt(ProjektDto projektDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if(projektDto == null)
                return BadRequest();

            Projekt projekt = Mapper.Map<ProjektDto, Projekt>(projektDto);

            _context.Projekty.Add(projekt);
            _context.SaveChanges();

            projektDto.Id = projekt.Id;

            return Created(new Uri(Request.RequestUri + "/"+projekt.Id),projektDto);
        }


        //PUT /api/projekty/1
        [HttpPut]
        public IHttpActionResult  PutProjekt(int id, ProjektDto projektDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            Projekt projekt = _context.Projekty.Where(w => w.Id == id).SingleOrDefault();
            if (projekt == null)
                return NotFound();

            projektDto.Id = id;

            Mapper.Map(projektDto, projekt);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/projekty/1
        [HttpDelete]
        public IHttpActionResult DeleteProjekt(int id)
        {
            Projekt projekt = _context.Projekty.Where(w => w.Id == id).SingleOrDefault();
            if (projekt == null)
                return NotFound();

            _context.Projekty.Remove(projekt);
            _context.SaveChanges();

            return Ok();
        }
    }
}
