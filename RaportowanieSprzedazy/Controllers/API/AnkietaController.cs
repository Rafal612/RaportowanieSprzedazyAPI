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
    public class AnkietaController : ApiController
    {
        private RaportowanieSprzedazyContext _context;

        public AnkietaController()
        {
            _context = new RaportowanieSprzedazyContext();
        }

        // GET /api/ankieta
        public IHttpActionResult GetAnkiety()
        {
            return Ok(_context.Ankiety.ToList().Select(Mapper.Map<Ankieta, AnkietaDto>));
        }

        // GET /api/ankieta/1
        public IHttpActionResult GetAnkieta(int id)
        {
            Ankieta ankieta = _context.Ankiety.Where(w => w.Id == id).SingleOrDefault();

            if (ankieta == null)
                return NotFound();

            return Ok(Mapper.Map<Ankieta, AnkietaDto>(ankieta));

        }

        // POST /api/ankieta
        [HttpPost]
        public IHttpActionResult PostAnkieta(AnkietaDto ankietaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (ankietaDto == null)
                return BadRequest();

            Ankieta ankieta = Mapper.Map<AnkietaDto, Ankieta>(ankietaDto);

            _context.Ankiety.Add(ankieta);
            _context.SaveChanges();
            ankietaDto.Id = ankieta.Id;
            return Created(new Uri(Request.RequestUri + "/" + ankieta.Id), ankietaDto);
        }

        // PUT /api/ankieta/1
        [HttpPut]
        public IHttpActionResult PutAnkieta(int id, AnkietaDto anikietaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Ankieta ankieta = _context.Ankiety.Where(w => w.Id == id).SingleOrDefault();
            if (ankieta == null)
                return NotFound();

            anikietaDto.Id = ankieta.Id;
            Mapper.Map(anikietaDto, ankieta);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE  /api/ankieta/1
        [HttpDelete]
        public IHttpActionResult DeleteAnkieta(int id)
        {
            Ankieta ankieta = _context.Ankiety.Where(w => w.Id == id).SingleOrDefault();
            if (ankieta == null)
                return NotFound();

            _context.Ankiety.Remove(ankieta);
            _context.SaveChanges();

            return Ok();
        }

    }
}
