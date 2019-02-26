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
    public class RodzajPytaniaController : ApiController
    {
        private RaportowanieSprzedazyContext _context;

        public RodzajPytaniaController()
        {
            _context = new RaportowanieSprzedazyContext();
        }

        //GET /api/rodzajpytania
        public IHttpActionResult GetRodzajePytan()
        {
            return Ok(_context.RodzajePytan.ToList().Select(Mapper.Map<RodzajPytania, RodzajPytaniaDto>));
        }

        // GET /api/rodzajpytania/1
        public IHttpActionResult GetRodzajPytania(int id)
        {
            RodzajPytania rodzajPytania = _context.RodzajePytan.Where(w => w.Id == id).SingleOrDefault();

            if (rodzajPytania == null)
                return NotFound();

            return Ok(Mapper.Map<RodzajPytania, RodzajPytaniaDto>(rodzajPytania));
        }

        // POST /api/rodzajpytania
        [HttpPost]
        public IHttpActionResult PostRodzajPytania(RodzajPytaniaDto rodzajPytaniaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (rodzajPytaniaDto == null)
                return BadRequest();

            RodzajPytania rodzajPytania = Mapper.Map<RodzajPytaniaDto, RodzajPytania>(rodzajPytaniaDto);

            _context.RodzajePytan.Add(rodzajPytania);
            _context.SaveChanges();

            rodzajPytaniaDto.Id = rodzajPytania.Id;

            return Created(new Uri(Request.RequestUri + "/" + rodzajPytania.Id), rodzajPytaniaDto);
        }


        //PUT /api/rodzajpytania/1
        [HttpPut]
        public IHttpActionResult PutRodzajPytania(int id, RodzajPytaniaDto rodzajPytaniaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            RodzajPytania rodzajPytania = _context.RodzajePytan.Where(w => w.Id == id).SingleOrDefault();
            if (rodzajPytania == null)
                return NotFound();

            rodzajPytaniaDto.Id = id;

            Mapper.Map(rodzajPytaniaDto, rodzajPytania);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/rodzajpytania/1
        [HttpDelete]
        public IHttpActionResult DeleteRodzajPytania(int id)
        {
            RodzajPytania rodzajPytania = _context.RodzajePytan.Where(w => w.Id == id).SingleOrDefault();
            if (rodzajPytania == null)
                return NotFound();

            _context.RodzajePytan.Remove(rodzajPytania);
            _context.SaveChanges();

            return Ok();
        }
    }

}

