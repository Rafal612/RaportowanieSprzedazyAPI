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
    public class OdpowiedzController : ApiController
    {
        private RaportowanieSprzedazyContext _context;

        public OdpowiedzController()
        {
            _context = new RaportowanieSprzedazyContext();
        }

        //GET /api/odpowiedz
        public IHttpActionResult GetOdpowiedzi()
        {
            return Ok(_context.Odpowiedzi.ToList().Select(Mapper.Map<Odpowiedz, OdpowiedzDto>));
        }

        // GET /api/odpowiedz/1
        public IHttpActionResult GetOdpowiedz(int id)
        {
            Odpowiedz odpowiedz = _context.Odpowiedzi.Where(w => w.Id == id).SingleOrDefault();

            if (odpowiedz == null)
                return NotFound();

            return Ok(Mapper.Map<Odpowiedz, OdpowiedzDto>(odpowiedz));
        }

        // POST /api/odpowiedz
        [HttpPost]
        public IHttpActionResult PostOdpowiedz(OdpowiedzDto odpowiedzDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (odpowiedzDto == null)
                return BadRequest();

            Odpowiedz odpowiedz = Mapper.Map<OdpowiedzDto, Odpowiedz>(odpowiedzDto);

            _context.Odpowiedzi.Add(odpowiedz);
            _context.SaveChanges();

            odpowiedzDto.Id = odpowiedz.Id;

            return Created(new Uri(Request.RequestUri + "/" + odpowiedz.Id), odpowiedzDto);
        }


        //PUT /api/odpowiedz/1
        [HttpPut]
        public IHttpActionResult PutOdpowiedz(int id, OdpowiedzDto odpowiedziDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Odpowiedz odpowiedz = _context.Odpowiedzi.Where(w => w.Id == id).SingleOrDefault();
            if (odpowiedz == null)
                return NotFound();

            odpowiedziDto.Id = id;

            Mapper.Map(odpowiedziDto, odpowiedz);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/odpowiedz/1
        [HttpDelete]
        public IHttpActionResult DeleteOdpowiedz(int id)
        {
            Odpowiedz odpowiedz = _context.Odpowiedzi.Where(w => w.Id == id).SingleOrDefault();
            if (odpowiedz == null)
                return NotFound();

            _context.Odpowiedzi.Remove(odpowiedz);
            _context.SaveChanges();

            return Ok();
        }
    }
}

