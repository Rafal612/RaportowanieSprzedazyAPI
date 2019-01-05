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
    public class StanowiskoController : ApiController
    {
        private RaportowanieSprzedazyContext _context;

        public StanowiskoController()
        {
            _context = new RaportowanieSprzedazyContext();
        }

        //GET /api/stanowisko
        public IHttpActionResult GetStanowiska()
        {
            return Ok(_context.Stanowiska.ToList().Select(Mapper.Map<Stanowisko, StanowiskoDto>));
        }

        // GET /api/stanowisko/1
        public IHttpActionResult GetStanowisko(int id)
        {
            Stanowisko stanowisko = _context.Stanowiska.Where(w => w.Id == id).SingleOrDefault();

            if (stanowisko == null)
                return NotFound();

            return Ok(Mapper.Map<Stanowisko, StanowiskoDto>(stanowisko));
        }

        // POST /api/stanowisko
        [HttpPost]
        public IHttpActionResult PostStanowisko(StanowiskoDto stanowiskoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (stanowiskoDto == null)
                return BadRequest();

            Stanowisko stanowisko = Mapper.Map<StanowiskoDto, Stanowisko>(stanowiskoDto);

            _context.Stanowiska.Add(stanowisko);
            _context.SaveChanges();

            stanowiskoDto.Id = stanowisko.Id;

            return Created(new Uri(Request.RequestUri + "/" + stanowisko.Id), stanowiskoDto);
        }


        //PUT /api/stanowisko/1
        [HttpPut]
        public IHttpActionResult PutStanowisko(int id, StanowiskoDto stanowiskoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Stanowisko stanowisko = _context.Stanowiska.Where(w => w.Id == id).SingleOrDefault();
            if (stanowisko == null)
                return NotFound();

            stanowiskoDto.Id = id;

            Mapper.Map(stanowiskoDto, stanowisko);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/stanowisko/1
        [HttpDelete]
        public IHttpActionResult DeleteStanowisko(int id)
        {
            Stanowisko stanowisko = _context.Stanowiska.Where(w => w.Id == id).SingleOrDefault();
            if (stanowisko == null)
                return NotFound();

            _context.Stanowiska.Remove(stanowisko);
            _context.SaveChanges();

            return Ok();
        }
    }
}
