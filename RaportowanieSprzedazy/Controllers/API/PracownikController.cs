using AutoMapper;
using RaportowanieSprzedazy.DTO;
using RaportowanieSprzedazy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace RaportowanieSprzedazy.Controllers.API
{
    public class PracownikController : ApiController
    {
        private RaportowanieSprzedazyContext _context;

        public PracownikController()
        {
            _context = new RaportowanieSprzedazyContext();
        }

        // GET /api/pracownik
        public IHttpActionResult GetPracownicy()
        {
            return Ok(_context.Pracownicy.ToList().Select(Mapper.Map<Pracownik,PracownikDto>));
        }

        // GET /api/pracownik/1
        public IHttpActionResult GetPracownik(int id)
        {
            Pracownik pracownik = _context.Pracownicy.Include(i => i.Projekty).Where( w => w.Id == id).SingleOrDefault();
            pracownik.ProjektyId = pracownik.Projekty.Select(s => s.Id).ToList();
            if (pracownik == null)
                return NotFound();

            return Ok(Mapper.Map<Pracownik,PracownikDto>(pracownik));

        }

        // POST /api/pracownik
        [HttpPost]
        public IHttpActionResult PostPracownik(PracownikDto pracownikDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (pracownikDto == null)
                return BadRequest();

            Pracownik pracownik = Mapper.Map<PracownikDto, Pracownik>(pracownikDto);

            _context.Pracownicy.Add(pracownik);
            _context.SaveChanges();
            pracownikDto.Id = pracownik.Id;
            pracownik.Projekty = _context.Projekty.Where(w => pracownik.ProjektyId.Contains(w.Id)).ToList();
            return Created(new Uri(Request.RequestUri + "/" + pracownik.Id), pracownikDto);
        }

        // PUT /api/prcownik/1
        [HttpPut]
        public IHttpActionResult PutPracownik(int id, PracownikDto pracownikDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            Pracownik pracownik = _context.Pracownicy.Where(w => w.Id == id).SingleOrDefault();
            if (pracownik == null)
                return NotFound();

            pracownikDto.Id = pracownik.Id;
            Mapper.Map(pracownikDto, pracownik);
            pracownik.Projekty = _context.Projekty.Where(w => pracownik.ProjektyId.Contains(w.Id)).ToList();
            _context.SaveChanges();

            return Ok();
        }

        // DELETE  /api/praconik/1
        [HttpDelete]
        public IHttpActionResult DeletePracowik(int id)
        {
            Pracownik pracownik = _context.Pracownicy.Where(w => w.Id == id).SingleOrDefault();
            if (pracownik == null)
                return NotFound();

            _context.Pracownicy.Remove(pracownik);
            _context.SaveChanges();

            return Ok();
        }
    }
}
