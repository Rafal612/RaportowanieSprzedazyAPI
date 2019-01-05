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
    public class PytanieController : ApiController
    {

        private RaportowanieSprzedazyContext _context;

        public PytanieController()
        {
            _context = new RaportowanieSprzedazyContext();
        }

        //GET /api/pytanie
        public IHttpActionResult GetPytania()
        {
            return Ok(_context.Pytania.ToList().Select(Mapper.Map<Pytanie, PytanieDto>));
        }

        // GET /api/pytanie/1
        public IHttpActionResult GetPytania(int id)
        {
            Pytanie pytanie = _context.Pytania.Where(w => w.Id == id).SingleOrDefault();

            if (pytanie == null)
                return NotFound();

            return Ok(Mapper.Map<Pytanie, PytanieDto>(pytanie));
        }

        // POST /api/pytanie
        [HttpPost]
        public IHttpActionResult PostPytanie(PytanieDto pytniaeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (pytniaeDto == null)
                return BadRequest();

            Pytanie pytanie = Mapper.Map<PytanieDto, Pytanie>(pytniaeDto);

            _context.Pytania.Add(pytanie);
            _context.SaveChanges();

            pytniaeDto.Id = pytanie.Id;

            return Created(new Uri(Request.RequestUri + "/" + pytanie.Id), pytniaeDto);
        }


        //PUT /api/pytanie/1
        [HttpPut]
        public IHttpActionResult PutPytanie(int id, PytanieDto pytanieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Pytanie pytanie = _context.Pytania.Where(w => w.Id == id).SingleOrDefault();
            if (pytanie == null)
                return NotFound();

            pytanieDto.Id = id;

            Mapper.Map(pytanieDto, pytanie);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/pytanie/1
        [HttpDelete]
        public IHttpActionResult DeletePytanie(int id)
        {
            Pytanie pytanie = _context.Pytania.Where(w => w.Id == id).SingleOrDefault();
            if (pytanie == null)
                return NotFound();

            _context.Pytania.Remove(pytanie);
            _context.SaveChanges();

            return Ok();
        }

    }
}
